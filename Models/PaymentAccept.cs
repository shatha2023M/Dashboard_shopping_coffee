﻿using System.ComponentModel.DataAnnotations;

namespace Dashboard_shopping_coffee.Models
{
    public class PaymentAccept
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string payment { get; set; }
    }
}
