using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.DataAccess.Concrete.EFCore
{
    public class ELPO_DbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }



        //protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        //{
        //    // configures many-to-many relationship
        //    modelBuilder.Entity<User>()
        //                .HasMany<Project>(s => s.Projects)
        //                .WithMany(c => c.Users)
        //                .Map(cs =>
        //                {
        //                    cs.MapLeftKey("UserRefId");
        //                    cs.MapRightKey("ProjectRefId");
        //                    cs.ToTable("ProjectUserRelation");
        //                });
        //    // configures one-to-many relationship between User and Role
        //    modelBuilder.Entity<User>()
        //        .HasRequired<Role>(s => s.Role)
        //        .WithMany(g => g.Users)
        //        .HasForeignKey<int>(s => s.RoleId);

        //    // configures one-to-many relationship between Project and Category
        //    modelBuilder.Entity<Project>()
        //        .HasRequired<Category>(s => s.Category)
        //        .WithMany(g => g.Projects)
        //        .HasForeignKey<int>(s => s.CategoryId);
        //}
    }
}