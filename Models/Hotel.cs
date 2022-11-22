using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TravelCompanyCore.Models
{
    internal class Hotel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public Models.Region? Region { get; set; }
        public Guid? RegionId { get; set; } // Один ко многим (в регионе много отелей)
        public Models.Contact? Manager { get; set; }
        public Guid? ManagerId { get; set; } // Один ко многим (управляющий может рулить несколькими заведениями)

        public override string ToString()
        {
            return Name;
        }
    }
}
