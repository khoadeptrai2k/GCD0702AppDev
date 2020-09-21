using GCD0702AppDev.Models;
using System.Linq;
using System.Web.Mvc;

namespace GCD0702AppDev.Controllers
{
	public class ProductsController : Controller
	{
		private ApplicationDbContext _context;

		public ProductsController()
		{
			_context = new ApplicationDbContext();
		}

		// GET: Products
		[HttpGet]
		public ActionResult Index()
		{
			var products = _context.Products.ToList();
			return View(products);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Product product)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			if (_context.Products.Any(p => p.Name.Contains(product.Name)))
			{
				ModelState.AddModelError("Name", "Product Name Already Exists.");
				return View();
			}

			var newProduct = new Product
			{
				Name = product.Name,
				Price = product.Price
			};

			_context.Products.Add(newProduct);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);

			if (productInDb == null)
			{
				return HttpNotFound();
			}

			_context.Products.Remove(productInDb);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}