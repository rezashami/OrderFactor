using Microsoft.EntityFrameworkCore;
using Simulation.Models;

namespace Simulation.Data
{
    public class SimulationContext : DbContext
    {
        public SimulationContext(DbContextOptions<SimulationContext> opt) : base(opt)
        {
        }


        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     modelBuilder.Entity<Factor>(table =>
        //     {
        //         table.OwnsMany(
        //             x => x.orderItems,
        //             orderItem =>
        //             {
        //                 orderItem.Property(x => x.product).HasColumnName("Product");
        //                 orderItem.Property(x => x.count).HasColumnName("Count");
        //             });
        //     });


            // modelBuilder.Entity<orderItem>()
            //     .HasOne(p => p.factor)
            //     .WithMany(b => b.orderItems);
        // }
        public DbSet<Factor> factors { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }

    }
}