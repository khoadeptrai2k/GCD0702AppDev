using GCD0702AppDev.Models;
using System.Collections.Generic;

namespace GCD0702AppDev.ViewModels
{
	public class ProductCategoryViewModel
	{
		public Product Product { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}