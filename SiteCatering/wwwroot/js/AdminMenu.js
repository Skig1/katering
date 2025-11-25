
document.addEventListener('DOMContentLoaded', function () {
const categories = document.querySelectorAll('.category-item');
const dishes = document.querySelectorAll('.dish-item');

// Функция для фильтрации блюд по выбранной категории
function filterDishes(selectedCategory) {
    dishes.forEach(dish => {
        const dishCategory = dish.getAttribute('data-category');

        if (selectedCategory === 'all' || dishCategory === selectedCategory) {
            dish.style.display = 'flex';
        } else {
            dish.style.display = 'none';
        }
    });
}

// Обработчик кликов по категориям
categories.forEach(category => {
    category.addEventListener('click', function () {
        // Снимаем активный класс со всех категорий
        categories.forEach(cat => cat.classList.remove('active'));

        // Добавляем активный класс к выбранной категории
        this.classList.add('active');

        // Фильтруем блюда
        const selectedCategory = this.getAttribute('data-category');
        filterDishes(selectedCategory);
    });
});

// Инициализация: показываем все блюда при загрузке
filterDishes('all');

// Делаем первую категорию активной по умолчанию
if (categories.length > 0) {
    categories[0].classList.add('active');
}
});
