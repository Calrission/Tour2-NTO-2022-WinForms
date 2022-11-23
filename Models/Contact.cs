using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TravelCompanyCore.Models
{
    internal class Contact
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PatronymicName { get; set; }
        public string? EmailAddress { get; set;}
        public string? PhoneNumber { get; set;}
        public List<Models.Role> Roles { get; set; } = new(); // Многие ко многим - у контакта может быть несколько ролей в системе
        public List<Hotel> Hotels { get; set; } = new(); // Типа один управлющий может работать в куче отелей. А почему бы и нет?

        public override string ToString() // Чтобы корректно работало отображение в родительском объекте при привязке в DataGridView
        {
            return string.IsNullOrEmpty(PatronymicName) ? string.Format("{0} {1}.", LastName, FirstName[0]) : string.Format("{0} {1}.{2}.", LastName, FirstName[0], PatronymicName[0]);
        }

        public string Fio {
            get
            {
                return ToString();
            }
        }        
    }
}
