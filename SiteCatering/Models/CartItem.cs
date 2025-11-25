namespace SiteCatering.Models
{
    public class CartItem
    {

        // Основной идентификатор блюда (из БД)
        public int DishId { get; set; }

        // Данные блюда, нужные для отображения в корзине
        public string Name { get; set; }
        public int Price { get; set; }      // Цена за единицу (int)
        public int Weight { get; set; }    // Вес за единицу (г)
        public string? PhotoUrl { get; set; } // Путь к изображению (может отсутствовать)

        // Количество в корзине
        public int Quantity { get; set; } = 1;

        // Рассчитываемые свойства (только для чтения)
        public int TotalPrice => Price * Quantity;
        public int TotalWeight => Weight * Quantity;

        // Конструктор для удобства
        public CartItem(int dishId, string name, int price, int weight, string? photoUrl = null)
        {
            DishId = dishId;
            Name = name ?? throw new ArgumentNullException(nameof(name), "Название блюда не может быть null");
            Price = price >= 0 ? price : throw new ArgumentException("Цена не может быть отрицательной");
            Weight = weight >= 0 ? weight : throw new ArgumentException("Вес не может быть отрицательным");
            PhotoUrl = photoUrl;
            Quantity = 1;
        }

        // Метод для изменения количества
        public void SetQuantity(int quantity)
        {
            if (quantity < 1)
                throw new ArgumentException("Количество должно быть ≥ 1");
            Quantity = quantity;
        }
    }
    
}

