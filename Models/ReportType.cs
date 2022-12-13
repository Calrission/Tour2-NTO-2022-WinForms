namespace TravelCompanyCore.Models
{
    internal class ReportType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Position { get; set; }

        public Tuple<DateTime, DateTime> GetDiaposonDates()
        {
            var now = DateTime.Now;
            var Year = now.Year;
            var Month = now.Month;

            if (Name == "Год")
            {
                return Tuple.Create(new DateTime(Year, 1, 1), new DateTime(Year, 12, 31));
            }
            else if (Name == "1 полугодие")
            {
                return Tuple.Create(new DateTime(Year, 1, 1), new DateTime(Year, 6, 30));
            }
            else if (Name == "2 полугодие")
            {
                return Tuple.Create(new DateTime(Year, 7, 1), new DateTime(Year, 12, 31));
            }
            else if (Name == "I квартал")
            {
                return Tuple.Create(new DateTime(Year, 1, 1), new DateTime(Year, 3, 31));
            }
            else if (Name == "II квартал")
            {
                return Tuple.Create(new DateTime(Year, 4, 1), new DateTime(Year, 6, 30));
            }
            else if (Name == "III квартал")
            {
                return Tuple.Create(new DateTime(Year, 7, 1), new DateTime(Year, 9, 30));
            }
            else if (Name == "IV квартал")
            {
                return Tuple.Create(new DateTime(Year, 10, 1), new DateTime(Year, 12, 31));
            }
            else if (Name == "Месяц")
            {
                return Tuple.Create(new DateTime(Year, Month, 1), new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month)));
            }
            else if (Name == "Неделя")
            {
                int DayOfWeek = ((int)DateTime.Now.DayOfWeek == 0) ? 6 : (int)DateTime.Now.DayOfWeek - 1;
                var start = DateTime.Now.AddDays(-DayOfWeek);
                var end = DateTime.Now.AddDays(6 - DayOfWeek);
                return Tuple.Create(start, end);
            }

            return null;
        }
    }
}
