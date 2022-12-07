using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyCore.Models
{
    internal class TourOrderStatusReason
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        /// <summary>
        /// Беспричинно
        /// </summary>
        [NotMapped]
        public static readonly Guid NoReasonId = Guid.Parse("12C563CD-03EA-41EF-9377-6955387F8702");
        /// <summary>
        /// Отказ клиента
        /// </summary>
        [NotMapped]
        public static readonly Guid ClientRefusingId = Guid.Parse("7C8D58AB-92EA-4059-A097-5D3E5928C3CB");
        /// <summary>
        /// Истечение срока бронирования
        /// </summary>
        [NotMapped]
        public static readonly Guid BookingExpirationId = Guid.Parse("2B5E1848-E7C3-48BE-8472-7387798C5818");
        /// <summary>
        /// Отказ Отеля
        /// </summary>
        [NotMapped]
        public static readonly Guid HotelRefusingId = Guid.Parse("9D4B962C-460B-4BD5-B8A5-F8636FA82284");
    }
}
