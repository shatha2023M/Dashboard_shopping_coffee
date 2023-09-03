using System.ComponentModel.DataAnnotations;

namespace Dashboard_shopping_coffee.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public string IdCostumers { get; set; }

        public int MyProductId { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public string Images { get; set; }

        public string Color { get; set; }

        public int Qty { get; set; }

        public double Tax { get; set; }
        public double Total { get; set; }
    }
}
