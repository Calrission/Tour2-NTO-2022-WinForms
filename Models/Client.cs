using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyCore.Models
{
    internal class Client
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ContactId { get; set; }

        public Models.Contact? Contact { get; set; }

        public Guid ClientTypeId { get; set; }

        public Models.ClientType? ClientType { get; set; }

        private string selfPhoneNumber;
        public string PhoneNumber  // Для физика возвращается его телефон, для юрика - телефон его Контакта
        {
            get
            {
                if (ContactId == Contact.BotId) return selfPhoneNumber;
                if (Contact != null) return Contact.PhoneNumber;
                else return "?????"; // Нужно при привязке?
            }
            set { selfPhoneNumber = value; }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
