
namespace TravelCompanyCore.Models
{
    internal class Food
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
