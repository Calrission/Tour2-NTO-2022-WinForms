﻿namespace TravelCompanyCore.Models
{
    internal class Tour
    {
        public Guid Id { get; set; }

        public Models.Hotel? Hotel { get; set; }

        public Guid HotelId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set;  }

        public int NightAmount
        {
            get;
            set;
        }

        public int DayAmount {
            get;
            set; 
        }

        public Models.Food? Food { get; set; }

        public Guid FoodId { get; set; }

        public Single Cost { get; set; }

        public string Description { get; set; }
    }
}
