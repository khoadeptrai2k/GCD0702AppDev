using GCD0702AppDev.Models;
using System.Collections.Generic;

namespace GCD0702AppDev.Repositories.Interface
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAllProducts();
		bool CreateProduct(Product product);
		bool EditProduct(Product product);

		bool DeleteProductById(int id);
		IEnumerable<Product> GetAllProductsWithSearchString(string searchString);

		Product GetProductById(int id);
	}
}
