namespace TravelCompanyCore.Models
{
    internal class Tour
    {
        public Guid Id { get; set; }

        public Models.Hotel? Hotel { get; set; }

        public Guid HotelId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set;  }

        private int dayAmount = 0;

        // TODO
        public int DayAmount {
            get {
                return dayAmount;
            }
            set {
                dayAmount = (int)Math.Floor((EndDateTime - StartDateTime).TotalDays);
            }
        }

        // TODO
        public int NightAmount { get; set; }

        public Models.Food? Food { get; set; }

        public Guid FoodId { get; set; }

        public Single Cost { get; set; }

        public string Description { get; set; }
    }
}
