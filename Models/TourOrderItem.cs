namespace TravelCompanyCore.Models
{
    /// <summary>
    /// Элемент заказа тура
    /// </summary>
    internal class TourOrderItem
    {
        public Guid Id { get; set; }
        public Guid TourOrderId { get; set; } // Для реализации связи один (тур) ко многим (элементам тура)
        public TourOrder? TourOrder { get; set; } // Для реализации связи один (тур) ко многим (элементам тура)
        public Guid TourId { get; set; }
        /// <summary>
        /// Ссылка на полное описание Тура
        /// </summary>
        public Tour? Tour { get; set; }
        /// <summary>
        /// Количество человек
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Цена тура (может отличаться от исходной цены)
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Итоговая стоимость (Цена на Количество человек)
        /// </summary>
        public double Cost { get; set; }

    }
}
