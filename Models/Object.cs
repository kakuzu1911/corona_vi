namespace Corona.Models
{
    public class countryInfo
    {
        public string flag { get; set; }
        public float lat { get; set; }
        public float _long { get; set; }
    }
    public class ObjectCorona
    {
        public string country { get; set; }
        public int cases { get; set; }
        public int todayCases { get; set; }
        public int deaths { get; set; }
        public int todayDeaths { get; set; }
        public int recovered { get; set; }
        public int active { get; set; }
        public float casesPerOneMillion { get; set; }
        public float deathsPerOneMillion { get; set; }
        public int critical { get; set; }
        public countryInfo countryInfo { get; set; }

    }
    public class ListMap
    {
        public string country { get; set; }
        public int cases { get; set; }
        public int deaths { get; set; }
        public float lat { get; set; }
        public float _long {get; set; }
    }
}