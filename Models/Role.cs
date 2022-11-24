using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyCore.Models
{
    internal class Role
    {
        // Константы системных ролей:
        [NotMapped]
        public static readonly Guid ClientContactId = Guid.Parse("6068F976-B092-475B-A8AB-BEA2DD2EDBBA"); // Id Контакта Клиента
        [NotMapped]
        public static readonly Guid AdministratorId = Guid.Parse("DA03F4BA-ED97-481B-8A47-ED885E08B6B5"); // Id Администратора
        [NotMapped]
        public static readonly Guid ManagerId = Guid.Parse("514F8200-EB0E-4241-9114-C7CBB6E5AC2F"); // Id Менеджера

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Models.Contact> Contacts { get; set; } = new(); // Многие ко многим
        public bool isSystem { get; set; } // Служебное свойство, позволяющее отделить системные роли от ролей, созданных пользователем
        public override string ToString()
        {
            return Name;
        }
    }
}
