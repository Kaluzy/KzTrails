using KzTrail.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KzTrail.Data
{
    public class KzTrailDbContext : DbContext
    {
        public KzTrailDbContext(DbContextOptions<KzTrailDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data fro difficulties
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("0f81ec6f-c675-4838-a967-4964b48d9b19"),
                    Name= "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("175e8a13-362f-4def-8a10-a8341433721f") ,
                    Name= "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("e3b6933e-319f-4a06-bc58-3e6c9f5baddf") ,
                    Name= "Hard"
                }
            };

            // Seed difficulties to the database 
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed data for Regions

            var regions = new List<Regions>()
            {
                new Regions()
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Code = "CA" ,
                    Name= "California",
                    RegionImageUrl= "california-img-url.jpg"
                },
                 new Regions()
                {
                    Id = Guid.Parse("1a39d5f9-a70c-45e9-b61b-8fe1b964286b"),
                    Code = "DE" ,
                    Name= "Delaware",
                    RegionImageUrl= "delaware-img-url.jpg"
                },
                  new Regions()
                {
                    Id = Guid.Parse("a23ea3b9-47c4-4e82-a8f7-9d2f42a0c46d"),
                    Code = "IL" ,
                    Name= "Illionois",
                    RegionImageUrl= "illionois-img-url.jpg"
                },
                   new Regions()
                {
                    Id = Guid.Parse("d52fa863-033f-410f-8516-1da939891ac9"),
                    Code = "KS" ,
                    Name= "Kansas",
                    RegionImageUrl= "kansas-img-url.jpg"
                }

            };
            modelBuilder.Entity<Regions>().HasData(regions);


        }

    }
}
