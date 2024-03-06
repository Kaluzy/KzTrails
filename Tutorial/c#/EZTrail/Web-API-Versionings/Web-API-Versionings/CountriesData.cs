using Web_API_Versionings.Models.Domian;

namespace Web_API_Versionings
{
    public static class CountriesData
    {
        public static List<Country> Get()
        {

            var countries = new[]
            {
                new {Id =1 , Name = "USA"},
                new {Id =2 , Name = "Ethiopia"},
                new {Id =3 , Name = "Spain"},
                new {Id =4 , Name = "France"},
                new {Id =5 , Name = "Italy"},
                new {Id =6 , Name = "South Africa"},
                new {Id =7 , Name = "China"}

            };

            return countries.Select(c => new Country { Id = c.Id, Name = c.Name }).ToList();

        }
    }
}
