using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;
using MakeYourMeal.DAL.Repository;

namespace MakeYourMeal.Service.Services
{
	public interface IIngridientService
	{
		IEnumerable<Ingredient> GetAllIngredients();
		Ingredient FindIngredient(string ingName);
		void AddNewIngredient(Ingredient newIng);
		void UpdateIngredient(Ingredient ingredient);
		void DeleteIngredient(string ingredientName);
		void SaveIngredient();
	}

	public class IngridientService : IIngridientService
	{
		private readonly IngredientRepository _ingredientRepository;

		public IngridientService(MakeYourMealEntities dbContext)
		{
			_ingredientRepository = new IngredientRepository(dbContext);
		}

		public IEnumerable<Ingredient> GetAllIngredients()
		{
			return _ingredientRepository.GetAll();
		}

		public Ingredient FindIngredient(string ingName)
		{
			var ing = _ingredientRepository.GetById(ingName);
			return ing;
		}

		public void AddNewIngredient(Ingredient newIng)
		{
			_ingredientRepository.Add(newIng);
			SaveIngredient();
		}

		public void UpdateIngredient(Ingredient ingredient)
		{
			_ingredientRepository.Update(ingredient);
			SaveIngredient();
		}

		public void DeleteIngredient(string ingredientName)
		{
			var ing = _ingredientRepository.GetById(ingredientName);
			_ingredientRepository.Delete(ing);
			SaveIngredient();
		}

		public void SaveIngredient()
		{
			_ingredientRepository.Save();
		}
	}
}
