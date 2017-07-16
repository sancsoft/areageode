namespace AreaGeode.Library.Models
{
    public class AreaGeodeCityView
    {
        public int Id { get; set; }
        public int AreaCode { get; set; }
        public string City { get; set; }
        public string StateAbbr { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string StateName { get; set; }
        public string CountryAbbr { get; set; }
    }
}
