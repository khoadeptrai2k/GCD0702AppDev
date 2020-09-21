using System.ComponentModel.DataAnnotations;

namespace GCD0702AppDev.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public double Price { get; set; }
	}
}