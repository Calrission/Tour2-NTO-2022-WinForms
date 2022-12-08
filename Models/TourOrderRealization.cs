using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyCore.Models
{
    internal class TourOrderRealization
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Клиент из справочника
        /// </summary>
        public Guid ClientId { get; set; }
        /// <summary>
        /// Ссылка на полное описание Клиента (нужен Include!)
        /// </summary>
        public Client? Client { get; set; }
        /// <summary>
        /// Тип оплаты (справочное значение)
        /// </summary>
        public Guid PaymentTypeId { get; set; }
        /// <summary>
        /// Ссылка на полное описание Типа оплаты (нужен Include!)
        /// </summary>
        public PaymentType? PaymentType { get; set; }
        /// <summary>
        /// Список туров в Заказе
        /// </summary>
        public List<TourOrderItem>? TourOrderItems { get; set; } // один тур ко многим элементам тура
        /// <summary>
        /// Суммарная стоимость Заказа
        /// </summary>
        public Double? TotalCost { get; set; }

        public bool BookingConfirmation { get; set; }
        public DateTime? RealizationDate { get; set; } // Пусть будет, может пригодится...

        public Guid TourOrderId { get; set; }
    }
}
