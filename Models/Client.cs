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

        public string PhoneNumber 
        {
            get { return Contact != null ? Contact.PhoneNumber : "-"; }
        }
    }
}
