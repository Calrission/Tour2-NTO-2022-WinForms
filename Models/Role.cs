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
        public static readonly Guid AdministratorId = Guid.Parse("6068F976-B092-475B-A8AB-BEA2DD2EDBBA"); // Id Администратора
        [NotMapped]
        public static readonly Guid ManagerId = Guid.Parse("6068F976-B092-475B-A8AB-BEA2DD2EDBBA"); // Id Менеджера

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
