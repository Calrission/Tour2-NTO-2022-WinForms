using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyCore.Models
{
    /// <summary>
    /// Заказы туров
    /// </summary>
    internal class TourOrder
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        /// <summary>
        /// Ссылка на полное описание Клиента (нужен Include!)
        /// </summary>
        public Client? Client { get; set; }
        /// <summary>
        /// Тип оплаты (справочное значение)
        /// </summary>
        public PaymentType? PaymentType { get; set; }
        /// <summary>
        /// Список туров в Заказе
        /// </summary>
        List<OrderItem>? ToursInCart { get; set; }
        /// <summary>
        /// Суммарная стоимость Заказа
        /// </summary>
        Double? TotalCost { get; set; }
    }
}
