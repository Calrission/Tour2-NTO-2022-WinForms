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

        public Guid ManagerId { get; set; }

        public Models.Contact? Manager { get; set; }

        public Guid TypeClientId { get; set; }

        public Models.TypeClient? TypeClient { get; set; }
    }
}
