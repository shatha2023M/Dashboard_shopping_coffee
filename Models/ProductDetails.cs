﻿using System.ComponentModel.DataAnnotations;

namespace Dashboard_shopping_coffee.Models
{
    public class ProductDetails
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public string Model { get; set; }

        public int Qty { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }
    }
}
