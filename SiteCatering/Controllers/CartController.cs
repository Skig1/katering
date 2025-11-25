using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteCatering.Domain;
using SiteCatering.Domain.Entities;
using SiteCatering.Infrastructure;
using SiteCatering.Models;
using System.Text.Json;

namespace SiteCatering.Controllers
{
    public class CartController : Controller
    {
        private const string SessionKey = "Cart";
        private readonly DataManager _dataManager;

        public CartController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        // Получение корзины из сессии
        private List<CartItem> GetCart()
        {
            var sessionData = HttpContext.Session.GetString(SessionKey);
            if (string.IsNullOrEmpty(sessionData))
                return new List<CartItem>();

            try
            {
                return JsonSerializer.Deserialize<List<CartItem>>(sessionData) ?? new List<CartItem>();
            }
            catch
            {
                // Если JSON невалидный — возвращаем пустую корзину
                return new List<CartItem>();
            }
        }

        // Сохранение корзины в сессию
        private void SaveCart(List<CartItem> cart)
        {
            var json = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString(SessionKey, json);
        }

        // Отображение корзины
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        // Добавление товара в корзину
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int dishId, int quantity = 1)
        {
            // Валидация входных данных
            if (quantity < 1 || quantity > 99)
            {
                TempData["ErrorMessage"] = "Количество должно быть от 1 до 99.";
                return Redirect(Request.Headers["Referer"].ToString()); // Возврат на ту же страницу
            }

            // Получение блюда из БД
            Dish? dish = await _dataManager.DishRepository.GetDishByIdAsync(dishId);
            if (dish == null)
            {
                TempData["ErrorMessage"] = $"Блюдо с ID {dishId} не найдено.";
                return Redirect(Request.Headers["Referer"].ToString());
            }

            // Проверка обязательных полей
            if (string.IsNullOrEmpty(dish.Name) || dish.Price == null || dish.Weight == null)
            {
                TempData["ErrorMessage"] = "Недостаточно данных о блюде.";
                return Redirect(Request.Headers["Referer"].ToString());
            }

            var cart = GetCart();

            // Поиск существующего товара в корзине
            var existingItem = cart.FirstOrDefault(item => item.DishId == dishId);

            if (existingItem != null)
            {
                existingItem.SetQuantity(existingItem.Quantity + quantity);
            }
            else
            {
                // Создание нового элемента корзины
                var cartItem = new CartItem(
                dishId: dish.Id,
                name: dish.Name,
                price: dish.Price ?? 0,
                weight: dish.Weight ?? 0,
                photoUrl: dish.Photo
                );
                cartItem.SetQuantity(quantity);
                cart.Add(cartItem);
            }

            SaveCart(cart);
            TempData["SuccessMessage"] = "Товар добавлен в корзину!";
            return Redirect(Request.Headers["Referer"].ToString()); // Остаёмся на той же странице
        }

        // Удаление товара из корзины
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int dishId)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(item => item.DishId == dishId);

            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
                TempData["SuccessMessage"] = "Товар удалён из корзины.";
            }
            else
            {
                TempData["ErrorMessage"] = "Товар не найден в корзине.";
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateQuantityAjax(int dishId, int quantity)
        {
            if (quantity < 1 || quantity > 99)
                return BadRequest("Количество должно быть от 1 до 99.");

            var cart = GetCart();
            var item = cart.FirstOrDefault(i => i.DishId == dishId);

            if (item == null)
                return NotFound("Товар не найден в корзине.");


            item.SetQuantity(quantity);
            SaveCart(cart);

            // Возвращаем обновлённые данные
            return Json(new
            {
                success = true,
                totalPrice = item.TotalPrice,
                totalCartPrice = cart.Sum(i => i.TotalPrice)
            });
        }

        // Очистка корзины
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Clear()
        {
            HttpContext.Session.Remove(SessionKey);
            TempData["SuccessMessage"] = "Корзина очищена.";
            return RedirectToAction("Index");
        }
    }
}
