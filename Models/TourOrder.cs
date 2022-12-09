using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// <summary>
        /// Текущий статус Заказа
        /// </summary>
        public Guid TourOrderStatusId { get; set; }
        /// <summary>
        /// Ссылка на полное описание Статуса (нужен Include!)
        /// </summary>
        public TourOrderStatus? TourOrderStatus { get; set; }
        /// <summary>
        /// Дата последней смены статуса
        /// </summary>
        public DateTime? TourOrderStatusShiftDate { get; set; }
        public Guid TourOrderStatusReasonId { get; set; }
        public TourOrderStatusReason TourOrderStatusReason { get; set; }
        /// <summary>
        /// Ссылка на расширенное описание Статуса (нужен Include к Причинам!)
        /// </summary>
        [NotMapped]
        public string StatusWitnReasonDescription
        {
            get
            {
                if (this.TourOrderStatus != null && TourOrderStatusReason != null)
                {
                    if (TourOrderStatusId == TourOrderStatus.CancellationId)
                        return String.Format("{0} ({1})", TourOrderStatus.Name, TourOrderStatusReason.Name);
                    else
                        return TourOrderStatus.Name;
                }
                else return "нет привязки";
            }
        }

        public TourOrderRealization convertToTourOrderRelalization(bool bookingConfiguration)
        {
            return new TourOrderRealization
            {
                Id = Guid.NewGuid(),
                TourOrderId = this.Id,
                ClientId = this.ClientId,
                PaymentTypeId = this.PaymentTypeId,
                TotalCost = this.TotalCost,
                RealizationDate = DateTime.Now,
                BookingConfirmation = bookingConfiguration
            };
        }
    }
}
