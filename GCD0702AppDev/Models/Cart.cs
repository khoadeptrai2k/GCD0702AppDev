namespace GCD0702AppDev.Models
{
	public class Cart
	{
		public int Id { get; set; }
		public string CustomerId { get; set; }
		public ApplicationUser Customer { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}