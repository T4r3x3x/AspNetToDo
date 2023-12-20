using DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace DAL.Implementations
{
    public class DataDbContext : DbContext
    {
        public DataDbContext() : base()
        {
           
        }

        public DataDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSnakeCaseNamingConvention();


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
          //  modelBuilder.Entity<ProjectsMemberships>().HasKey(pm => new { pm.Id, pm.Project, pm.Person, pm.Role });
		}

		public DbSet<TaskEntity> TaskEntities { get; set; }
        public DbSet<User> Persons { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectsMemberships> ProjectsMemberships { get; set; }

    }
}
