

namespace StyleSphere.Domain.Entities
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string image { get; set; }
        public int rating { get; set; }
        public string? buyimage { get; set; }
        public string description { get; set; }

    }
}
