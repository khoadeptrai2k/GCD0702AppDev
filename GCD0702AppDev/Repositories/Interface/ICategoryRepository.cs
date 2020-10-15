using GCD0702AppDev.Models;
using System.Collections.Generic;

namespace GCD0702AppDev.Repositories.Interface
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> GetCategories();
	}
}