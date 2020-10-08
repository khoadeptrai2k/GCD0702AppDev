using GCD0702AppDev.Dao;
using GCD0702AppDev.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GCD0702AppDev.Controllers.Api
{
	public class ProductsController : ApiController
	{
		private ApplicationDbContext _context;
		public ProductsController()
		{
			_context = new ApplicationDbContext();
		}

		[HttpGet]
		public IHttpActionResult GetAllProducts()
		{
			var products = _context.Products.ToList();

			return Ok(products);
		}

		[HttpGet]

		public IHttpActionResult GetProductById(int id)
		{
			var product = _context.Products
				.Include(p => p.Category)
				.SingleOrDefault(p => p.Id == id);

			if (product == null)
				return NotFound();

			var productDao = new ProductDao
			{
				Id = product.Id,
				Name = product.Name,
				Price = product.Price,
				CategoryName = product.Category.Name
			};

			return Ok(productDao);
		}

		[HttpDelete]
		public IHttpActionResult DeleteById(int id)
		{
			var product = _context.Products
				.Include(p => p.Category)
				.SingleOrDefault(p => p.Id == id);

			if (product == null)
				return NotFound();

			_context.Products.Remove(product);
			_context.SaveChanges();

			return Ok("Product with Id " + product.Id + " deleted...");
		}
	}
}
