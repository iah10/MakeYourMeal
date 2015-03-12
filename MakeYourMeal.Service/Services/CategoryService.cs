using System.Collections.Generic;
using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;
using MakeYourMeal.DAL.Repository;

namespace MakeYourMeal.Service.Services
{
	public interface ICategoryService
	{
		IEnumerable<Category> GetAllCategories();
	}

	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(MakeYourMealEntities dbcontext)
		{
			_categoryRepository =  new CategoryRepository(dbcontext);
		}

		public IEnumerable<Category> GetAllCategories()
		{
			return _categoryRepository.GetAll();
		}
	}
}