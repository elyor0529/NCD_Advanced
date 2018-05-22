
namespace NCD.Infrastructure
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NCD.Application.Domain;
    using NCD.Application.Services;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext() : base("DefaultConnection", false)
        {
        }

        public IDbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //to table name 'person'
            modelBuilder.Entity<Person>().ToTable("Person");

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
