using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TravelCompanyCore.Models
{
    internal class Contact
    {
        [NotMapped]
        public static readonly Guid BotId = Guid.Parse("EE91E6A7-CB38-4DB0-B702-04D0903CF231"); // Id Бота Пахома, чтоб было с чем сравнивать
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
            return FullName;
        }

        [NotMapped]
        public string ShortFullName
        {
            get
            {
                if (Id == BotId) return "сам клиент";
                return string.IsNullOrEmpty(PatronymicName) ? string.Format("{0} {1}.", LastName, FirstName[0]) : string.Format("{0} {1}.{2}.", LastName, FirstName[0], PatronymicName[0]);
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                if (Id == BotId) return "сам клиент";
                return string.IsNullOrEmpty(PatronymicName) ? string.Format("{0} {1}", LastName, FirstName) : string.Format("{0} {1} {2}", LastName, FirstName, PatronymicName);
            }
        }

        [NotMapped]
        public string ListOfRoles // Строковый перечень ролей через слэш
        {
            get
            {
                if (Roles != null)
                {
                    return string.Join("\\", Roles);
                }
                else return "не определены";
            }
        }
    }
}
