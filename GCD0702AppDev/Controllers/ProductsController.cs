using GCD0702AppDev.Models;
using GCD0702AppDev.Repositories.Interface;
using GCD0702AppDev.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GCD0702AppDev.Controllers
{
	public class ProductsController : Controller
	{
		private ApplicationDbContext _context;
		private IProductRepository _productRepos;

		public ProductsController(IProductRepository productRepos)
		{
			_context = new ApplicationDbContext();
			_productRepos = productRepos;
		}

		// GET: Products
		[HttpGet]
		public ActionResult Index(string? searchString)
		{
			if (!String.IsNullOrEmpty(searchString))
			{
				return View(_productRepos.GetAllProductsWithSearchString(searchString).ToList());
			}

			return View(_productRepos.GetAllProducts().ToList());
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public ActionResult Create()
		{
			var viewModel = new ProductCategoryViewModel
			{
				Categories = _context.Categories.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		[ValidateAntiForgeryToken]
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
				Price = product.Price,
				CategoryId = product.CategoryId
			};

			_context.Products.Add(newProduct);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		[Authorize(Roles = "admin")]

		public ActionResult Delete(int id)
		{
			if (!_productRepos.DeleteProductById(id))
			{
				return HttpNotFound();
			}

			return RedirectToAction("Index");
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public ActionResult Edit(int id)
		{
			var productInDb = _productRepos.GetProductById(id);

			if (productInDb == null)
			{
				return HttpNotFound();
			}

			var viewModel = new ProductCategoryViewModel
			{
				Product = productInDb,
				Categories = _context.Categories.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public ActionResult Edit(Product product)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			if (!_productRepos.EditProduct(product))
			{
				return HttpNotFound();
			}

			return RedirectToAction("Index");
		}
	}
}