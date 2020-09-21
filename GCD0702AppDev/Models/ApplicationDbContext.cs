using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GCD0702AppDev.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
				: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public DbSet<Product> Products { get; set; }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}