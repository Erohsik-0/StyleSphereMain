
using System.ComponentModel.DataAnnotations;


namespace StyleSphere.Domain.Entities
{
    public class CartItem
    {

        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int Quantity { get; set; }
    }
}
