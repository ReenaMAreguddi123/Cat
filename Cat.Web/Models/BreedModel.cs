using Newtonsoft.Json;

namespace Cat.Web.Models
{
    public class BreedModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public  string Description { get; set; }

        public string Temperament { get; set; }

        public string LifeSpan { get; set; }

        public string AltNames { get; set; }

        [JsonProperty(PropertyName = "wikipedia_url")]
        public string WikipediaUrl { get; set; }

        [JsonProperty(PropertyName = "vetstreet_url")]
        public string VetStreetUrl { get; set; }

        public string Origin { get; set; }

        [JsonProperty(PropertyName = "Weight_Imperial")]
        public string WeightImperial { get; set; }

        public int Experimental { get; set; }

        public int Hairless { get; set; }

        public int Natural { get; set; }

        public int Rare { get; set; }

        public int Rex { get; set; }

        public int SuppressTail { get; set; }

        public int ShortLegs { get; set; }

        public int Hypoallergenic { get; set; }

        public int Adaptability { get; set; }

        public int AffectionLevel { get; set; }

        public string CountryCode { get; set; }

        public int ChildFriendly { get; set; }

        public int DogFriendly { get; set; }

        public int EnergyLevel { get; set; }

        public int Grooming { get; set; }

        public int HealthIssues { get; set; }

        public int Intelligence { get; set; }

        public int SheddingLevel { get; set; }

        public int SocialNeeds { get; set; }

        public int StrangerFriendly { get; set; }

        public int Vocalisation { get; set; }

        public ImageModel Image { get; set; }
    }

}

