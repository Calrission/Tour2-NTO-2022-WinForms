using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyCore.Models
{
    internal class TourOrderRealization: TourOrder
    {
        public bool BookingConfirmation { get; set; }
        public DateTime? RealizationDate { get; } // Пусть будет, может пригодится...
    }
}
