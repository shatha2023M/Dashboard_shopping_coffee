using Dashboard_shopping_coffee.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard_shopping_coffee.Data
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }
            public DbSet<Product> Products { get; set; }
            public DbSet<ProductDetails> ProductDetails { get; set; }
            public DbSet<Costumers> Customers { get; set; }

            public DbSet<Invoice> Invoices { get; set; }

            public DbSet<PaymentAccept> PaymentAccept { get; set; }

            public DbSet<Cart> Carts { get; set; }
        }
    
}
