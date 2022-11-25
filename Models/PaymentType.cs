using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyCore.Models
{
    /// <summary>
    /// Тип оплаты
    /// </summary>
    internal class PaymentType
    {
    /// <summary>
    /// Кредит
    /// </summary>
    [NotMapped]
    public static readonly Guid CreditId = Guid.Parse("4322B228-5CBC-4291-959A-F71222949833"); // Id кредита
    /// <summary>
    /// Предоплата
    /// </summary>
    [NotMapped]
    public static readonly Guid PrepaymentId = Guid.Parse("9C67C785-C4A8-4576-8D52-205DCBB4F997"); // Id предоплаты
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Строковое представление типа оплаты для вывода в грид
        /// </summary>
        public override string ToString()
        {
            return Name;
        }
    }
}
