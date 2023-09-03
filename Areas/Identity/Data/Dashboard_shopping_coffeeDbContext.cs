using Dashboard_shopping_coffee.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dashboard_shopping_coffee.Data;

public class Dashboard_shopping_coffeeDbContext : IdentityDbContext<Dashboard_shopping_coffeeUser>
{
    public Dashboard_shopping_coffeeDbContext(DbContextOptions<Dashboard_shopping_coffeeDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
