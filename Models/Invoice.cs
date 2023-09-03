using System.ComponentModel.DataAnnotations;

namespace Dashboard_shopping_coffee.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public int CostumerID { get; set; }

        public int ProductID { get; set; }


        public double Price { get; set; }

        public int QTY { get; set; }

        public float Tax { get; set; }

        public float Discount { get; set; }

        public double Total { get; set; }
    }
}
