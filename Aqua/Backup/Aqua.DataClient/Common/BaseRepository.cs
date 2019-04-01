using System.Collections.Generic;
using System.Linq;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.DataClient.Common
{
	public abstract class BaseRepository<T, TSource> : IRepository<T>
	{

		#region Constructors

		/// <summary>
		/// Default Constructor
		/// </summary>
		public BaseRepository()
		{
		}

		#endregion

		#region Protected/Private Methods

		/// <summary>
		/// Select a colleciton of items from the data source
		/// </summary>
		/// <param name="criteria">Criteria for querying the data source</param>
		/// <returns>Collection of Item</returns>
		protected TSource GetItem(CommandCriteria criteria)
		{
			IQueryable<TSource> query = this.GetQuery(criteria);
			return this.DataContext.ExecuteQuery<TSource>(query).SingleOrDefault();
		}

		/// <summary>
		/// Select a colleciton of items from the data source
		/// </summary>
		/// <param name="criteria">Criteria for querying the data source</param>
		/// <returns>Collection of Item</returns>
		protected IEnumerable<TSource> GetItemCollection(CommandCriteria criteria)
		{
			IQueryable<TSource> query = this.GetCollectionQuery(criteria);
			return this.DataContext.ExecuteQuery<TSource>(query).ToList();
		}

		/// <summary>
		/// Get the LINQ Query for retrieving an item.
		/// </summary>
		/// <param name="criteria">Command Criteria</param>
		/// <returns>Queryable Context for ADO.NET DS</returns>
		protected virtual IQueryable<TSource> GetQuery(CommandCriteria criteria)
		{
			return null;
		}

		/// <summary>
		/// Get the LINQ Query for retrieving a collection of items.
		/// </summary>
		/// <param name="criteria">Command Criteria</param>
		/// <returns>Queryable Context for ADO.NET DS</returns>
		protected virtual IQueryable<TSource> GetCollectionQuery(CommandCriteria criteria)
		{
			return null;
		}

		/// <summary>
		/// Data Context (Data Source)
		/// </summary>
		protected abstract IDataContext DataContext { get; }

		public virtual T Select(CommandCriteria criteria)
		{
			return default(T);
		}

		public virtual IEnumerable<T> SelectCollection(CommandCriteria criteria)
		{
			return null;
		}

		#endregion
	}
}