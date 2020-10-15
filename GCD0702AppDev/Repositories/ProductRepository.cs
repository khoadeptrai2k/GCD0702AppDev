﻿using GCD0702AppDev.Models;
using GCD0702AppDev.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GCD0702AppDev.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private ApplicationDbContext _context;

		public ProductRepository()
		{
			_context = new ApplicationDbContext();
		}
		public bool CreateProduct(Product product)
		{
			throw new NotImplementedException();
		}

		public bool DeleteProductById(int id)
		{
			var productInDb = GetProductById(id);

			if (productInDb == null) return false;

			_context.Products.Remove(productInDb);
			_context.SaveChanges();

			return true;
		}

		public bool EditProduct(Product product)
		{
			var productInDb = GetProductById(product.Id);

			if (productInDb == null) return false;

			productInDb.Name = product.Name;
			productInDb.Price = product.Price;
			productInDb.CategoryId = product.CategoryId;

			_context.SaveChanges();

			return true;
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return _context.Products
			.Include(p => p.Category);
		}

		public IEnumerable<Product> GetAllProductsWithSearchString(string searchString)
		{
			IEnumerable<Product> products = GetAllProducts();
			return products.Where(
					s => s.Name.Contains(searchString) ||
					s.Category.Name.Contains(searchString));
		}

		public Product GetProductById(int id)
		{
			return _context.Products.SingleOrDefault(p => p.Id == id);
		}
	}
}