using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MakeYourMeal.DAL.Infrastructure
{
	/// <summary>
	/// Defines genral and common methods that are used across all models' repositories
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T> where T : class
	{
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		void Delete(Expression<Func<T, bool>> where);
		void Save();
		T GetById(long id);
		T GetById(string id);
		T Get(Expression<Func<T, bool>> where);
		IEnumerable<T> GetAll();
		IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
	}
}
