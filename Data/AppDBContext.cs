using BugProject.Controllers;
using BugProject.Models;
using FinanceProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FinanceProject.Data
{
    public class AppDBContext : IdentityDbContext<Users>
    {
        public AppDBContext(DbContextOptions dbContextOPtions)
            : base(dbContextOPtions)

        {
            
        }

      
        public DbSet<Bugs> bugs { get; set; }
        public DbSet<Bug_Atachment> bug_Atachments { get; set; }
       






        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);




            {
                builder.Entity<Bugs>()
                    .HasOne(b => b.Bug_Atachment)
                    .WithOne(ba => ba.Bugs)
                    .HasForeignKey <Bug_Atachment> (ba => ba.Bugsid);

                base.OnModelCreating(builder);



            }
















            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
