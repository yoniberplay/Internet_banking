using Internet_banking.Infrastucture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Infrastucture.Identity.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");

            builder.Entity<ApplicationUser>(entity =>
            {
            entity.ToTable("Users");
                });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Roles");
            });

            builder.Entity<IdentityRole<String>>(entity =>
            {
                entity.ToTable("UserRoles");
            }); 

            builder.Entity<IdentityUserLogin<String>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
        }
    }
}
