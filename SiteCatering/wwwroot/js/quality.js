document.addEventListener('DOMContentLoaded', function () {
    // Находим все поля количества
    const quantityInputs = document.querySelectorAll('input[name="quantity"]');

    quantityInputs.forEach(input => {
        input.addEventListener('change', function () {
            const dishId = this.getAttribute('data-dish-id');
            const quantity = parseInt(this.value);

            if (isNaN(quantity) || quantity < 1 || quantity > 99) {
                alert('Количество должно быть от 1 до 99.');
                return;
            }

            // Отправляем AJAX-запрос
            fetch('/Cart/UpdateQuantityAjax', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                    'RequestVerificationToken':
                        document.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: `dishId=${dishId}&quantity=${quantity}`
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        // Обновляем цену для этого товара
                        const row = this.closest('tr');
                        row.querySelector('.item-total').textContent = data.totalPrice;

                        // Обновляем общую сумму корзины
                        document.getElementById('total-cart-price').textContent = data.totalCartPrice;
                    } else {
                        alert('Ошибка при обновлении корзины.');
                    }
                })
                .catch(error => {
                    console.error('Ошибка:', error);
                    //alert('Не удалось обновить корзину.');
                });
        });
    });
});