using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanyCore.Models
{
    internal class Tour
    {
        public Guid Id { get; set; }

        public Models.Hotel? Hotel { get; set; }

        public Guid HotelId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        private int nights;
        public int NightsAmount {
            get { return (int)Math.Floor((EndDateTime - StartDateTime).TotalDays); }
            set { nights = NightsAmount; }
        }
        private int days;
        public int DaysAmount
        {
            get { return NightsAmount + 1; }
            set { days = NightsAmount; }
        }
        [NotMapped]
        public string DaysPerNights { get { return string.Format("{0}\\{1}", DaysAmount.ToString(), NightsAmount.ToString()); } }

        public Models.Food? Food { get; set; }

        public Guid FoodId { get; set; }

        public Single Cost { get; set; }

        public string Description { get; set; }

    }
}
