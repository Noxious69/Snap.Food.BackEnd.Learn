using Learn.FoodApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.FoodApp.Infrastructure.Data
{
    public class LearnFoodAppDB : DbContext
    {
        public DbSet<ApplicationUsers> ApplicationUsers { get; set; }

        public DbSet<Restaurant> restaurants { get; set; }

        public DbSet<Food> Foods { get; set; }

        public LearnFoodAppDB(DbContextOptions<LearnFoodAppDB> option)
            : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<ApplicationUsers>()
                .HasKey(p => p.Username);
        }

    }
}
