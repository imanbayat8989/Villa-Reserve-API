using Microsoft.EntityFrameworkCore;
using Villa_VillaAPI.Models;

namespace Villa_VillaAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
		public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Villa> villas { get; set; }

		public DbSet<VillaNumber> villaNumbers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Villa>().HasData(
				new Villa
				{
					Id = 1,
					Name = "Royal",
					Details = "Some dummy text",
					ImageUrl = "https://www.raffles.com/assets/0/72/2764/2765/2786/6c64d74a-f58d-4de2-a61e-8666413a354c.jpg",
					Occupancy = 5,
					Rate = 200,
					Meter = 550,
					Amenity = "",
					CreateDate = DateTime.Now,
				},
				new Villa
				{
					Id = 2,
					Name = "Swimpoll",
					Details = "Some dummy text",
					ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/301483778.jpg?k=b1f449beb857de98e8287c34956b672956926c2d03ac185ff8d9a348622c157a&o=&hp=1",
					Occupancy = 6,
					Rate = 200,
					Meter = 450,
					Amenity = "",
					CreateDate = DateTime.Now,
				},
				new Villa
				{
					Id = 3,
					Name = "partyVilla",
					Details = "Some dummy text",
					ImageUrl = "https://media.vrbo.com/lodging/30000000/29490000/29484300/29484212/b479b134.c10.jpg",
					Occupancy = 6,
					Rate = 200,
					Meter = 350,
					Amenity = "",
					CreateDate = DateTime.Now,
				}
				);
		}
	}
}
