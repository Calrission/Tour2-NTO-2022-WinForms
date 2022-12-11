namespace TravelCompanyCore.Models
{
    internal class Region
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Hotel> Hotels { get; set; } = new();

        public override string ToString()
        {
            return Name;
        }
    }
}
