using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Small_e_commers.Data;
using Small_e_commers.Models;
using TestAPIAhmedElmohamdyCours.Models;

namespace TestAPIAhmedElmohamdyCours.Data
{
    public class AppDbContext : IdentityDbContext<AppUserDbContext>
	{
        public AppDbContext(DbContextOptions option ) : base (option)
        {

            
        }

        public DbSet<Items>  items { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }


    }
}
