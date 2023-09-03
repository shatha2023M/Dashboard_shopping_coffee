using System.ComponentModel.DataAnnotations;

namespace Dashboard_shopping_coffee.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }
    }
}
