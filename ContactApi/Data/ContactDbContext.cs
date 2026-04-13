using Microsoft.EntityFrameworkCore;
using Microsoft.Identity;
using ContactApi.Model;
using Microsoft.EntityFrameworkCore.SqlServer;
using ContactApi.Repository;
using ContactApi.Dto;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ContactApi.Data
{
        public class ContactDbContext : IdentityDbContext<ApplicationUser>
        {


            public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
            {
            }
            public DbSet<Mycontact> Mycontacts{ get; set; }
            

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Mycontact>();
                   
                //.OnDelete(DeleteBehavior.Restrict);
            }
        }

    
}
