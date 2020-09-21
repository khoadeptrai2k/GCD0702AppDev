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
		public ActionResult Index()
		{
			var products = _context.Products.ToList();
			return View(products);
		}
	}
}