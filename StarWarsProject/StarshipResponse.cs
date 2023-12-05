using System.Security.Cryptography.X509Certificates;

namespace StarWarsProject
{
    public class StarshipResponse
    {
        public string? Next { get; set; }
        public string? Previous { get; set; }
        public List<Starship>? results { get; set; }
            
    }

    public class Starship 
    {

        public string? manufacturer { get; set; }

        public string? name { get; set; }
    }

}