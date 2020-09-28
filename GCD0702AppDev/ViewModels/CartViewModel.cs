using GCD0702AppDev.Models;
using System.Collections.Generic;

namespace GCD0702AppDev.ViewModels
{
	public class CartViewModel
	{
		public Product Product { get; set; }
		public IEnumerable<Product> Products { get; set; }
	}
}