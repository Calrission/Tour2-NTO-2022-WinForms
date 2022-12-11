using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanyCore.Models
{
    internal class ClientType
    {

        [NotMapped]
        public static readonly Guid IndividualId = Guid.Parse("cd3b7458-6f73-49c3-a56b-af81101cc3cd"); // Id физика
        [NotMapped]
        public static readonly Guid EntityId = Guid.Parse("65bc9547-acd5-420e-8d60-0f037bfc4e79"); // Id юрика
        public Guid Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
