using GCD0702AppDev.Models;
using GCD0702AppDev.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace GCD0702AppDev.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _context;
		public CategoryRepository()
		{
			_context = new ApplicationDbContext();
		}
		public IEnumerable<Category> GetCategories()
		{
			return _context.Categories.ToList();
		}
	}
}