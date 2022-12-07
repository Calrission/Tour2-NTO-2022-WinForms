using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyCore.Models
{
    internal class TourOrderStatus
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ReasonId { get; set; }
        /// <summary>
        /// Черновик
        /// </summary>
        [NotMapped]
        public static readonly Guid DraftId = Guid.Parse("DDEB0FF0-7E89-425D-AF37-7D97F5571F5B");
        /// <summary>
        /// Бронь
        /// </summary>
        [NotMapped]
        public static readonly Guid BookingId = Guid.Parse("5F24C6F9-704A-403A-B30B-04E2F361A403");
        /// <summary>
        /// Отмена
        /// </summary>
        [NotMapped]
        public static readonly Guid CancellationId = Guid.Parse("0A593624-6F2F-4FEA-BFF3-0A67904DE4E1");
        /// <summary>
        /// Оплачен
        /// </summary>
        [NotMapped]
        public static readonly Guid PaidId = Guid.Parse("D40D224C-D35A-4E2E-9D85-4EFAF3CA701E");
        /// <summary>
        /// Продан
        /// </summary>
        [NotMapped]
        public static readonly Guid RealizedId = Guid.Parse("4A31DF95-6013-4AC7-AA88-C7E9ED348E02");
        /// <summary>
        /// Действует
        /// </summary>
        [NotMapped]
        public static readonly Guid RunId = Guid.Parse("47E57AA5-7BFE-45BE-A017-C41903F40068");
        /// <summary>
        /// Завершён
        /// </summary>
        [NotMapped]
        public static readonly Guid ClosedId = Guid.Parse("DFFE7872-A3C0-436E-84BA-29BDCB3FAF94");
        public override string ToString()
        {
            return Name;
        }
    }

}
