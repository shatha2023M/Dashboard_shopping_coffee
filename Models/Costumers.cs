﻿using System.ComponentModel.DataAnnotations;

namespace Dashboard_shopping_coffee.Models
{
    public class Costumers
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }
    }
}
