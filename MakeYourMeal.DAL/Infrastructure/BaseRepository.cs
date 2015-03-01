using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace MakeYourMeal.DAL.Infrastructure
{
	/// <summary>
	/// Implements the general repository methods
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class RepositoryBase<T> where T : class
	{
		private MakeYourMealEntities _dataContext;
		private readonly IDbSet<T> _dbset;
		private bool _disposed = false;


		protected RepositoryBase(MakeYourMealEntities dbContext)
		{
			_dataContext = dbContext;
			_dbset = DataContext.Set<T>();
		}


		protected MakeYourMealEntities DataContext
		{
			get { return _dataContext; }
		}

		public virtual void Add(T entity)
		{
			_dbset.Add(entity);
		}
		public virtual void Update(T entity)
		{
			_dbset.Attach(entity);
			_dataContext.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Delete(T entity)
		{
			_dbset.Remove(entity);
		}

		public virtual void Delete(Expression<Func<T, bool>> where)
		{
			IEnumerable<T> objects = _dbset.Where<T>(where).AsEnumerable();
			foreach (T obj in objects)
				_dbset.Remove(obj);
		}

		public virtual T GetById(long id)
		{
			return _dbset.Find(id);
		}

		public virtual T GetById(string id)
		{
			return _dbset.Find(id);
		}

		public virtual IEnumerable<T> GetAll()
		{
			return _dbset.ToList();
		}

		public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
		{
			return _dbset.Where(where).ToList();
		}

		public T Get(Expression<Func<T, bool>> where)
		{
			return _dbset.Where(where).FirstOrDefault<T>();
		}

		public void Save()
		{
			try
			{
				_dataContext.SaveChanges();

			}
			catch (DbEntityValidationException e)
			{
				foreach (var eve in e.EntityValidationErrors)
				{
					Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						Debug.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
							ve.PropertyName,
							eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
							ve.ErrorMessage);
					}
				}
				throw;
			}
		}
	}
}
