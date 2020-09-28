using GCD0702AppDev.Models;
using GCD0702AppDev.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GCD0702AppDev.Controllers
{
	public class CartsController : Controller
	{
		private readonly ApplicationDbContext _context;
		public CartsController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Carts
		[Authorize(Roles = "admin")]
		public ActionResult Index()
		{
			var carts = _context.Carts
				.Include(s => s.Customer)
				.Include(s => s.Product)
				.ToList();
			return View(carts);
		}

		[Authorize(Roles = "guest")]
		[HttpGet]
		public ActionResult Create()
		{
			var viewModel = new CartViewModel
			{
				Products = _context.Products.ToList()
			};


			return View(viewModel);
		}

		[Authorize(Roles = "guest")]
		[HttpPost]
		public ActionResult Create(Product product)
		{
			Cart cart = new Cart
			{
				CustomerId = User.Identity.GetUserId(),
				ProductId = product.Id
			};

			_context.Carts.Add(cart);
			_context.SaveChanges();
			return RedirectToAction("Mine");
		}

		[HttpGet]
		[Authorize(Roles = "guest")]
		public ActionResult Mine()
		{
			var userId = User.Identity.GetUserId();

			var carts = _context.Carts
				.Where(c => c.CustomerId == userId)
				.Include(c => c.Product)
				.ToList();

			return View(carts);
		}
	}
}