using System.Collections.Generic;
using System.Linq;

namespace Infragistics.Guidance.Aqua.DataClient.Common
{
	public interface IDataContext
	{

		/// <summary>
		/// Select a colleciton of items from the data source
		/// </summary>
		/// <returns>Collection of Item</returns>
		IEnumerable<TQuery> ExecuteQuery<TQuery>(IQueryable<TQuery> query);

	}
}