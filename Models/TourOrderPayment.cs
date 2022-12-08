using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyCore.Models
{
    internal class TourOrderPayment
    {
        public Guid Id { get; set; }
        public Guid TourOrderId { get; set; }
        public DateTime? PaymentDate { get; set; } // Пусть будет, может пригодится...
        public Double? TotalCost { get; set; }
    }
}
