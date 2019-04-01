using System.Collections.Generic;
using System.Linq;

namespace Infragistics.Guidance.Aqua.DataClient.Common
{
		
	/// <summary>
	/// Base Data Mapper Class Used for mapping the model from a data source.
	/// </summary>
	/// <typeparam name="T">Model Class</typeparam>
	/// <typeparam name="TSource">Data Source Class</typeparam>
	public abstract class BaseDataMapper<T, TSource>
	{

		#region Constructors

		/// <summary>
		/// Default Constructor
		/// </summary>
		public BaseDataMapper()
		{
		}

		#endregion

		#region Abstract/Virtual Methods

		/// <summary>
		/// Handles mapping a single model item
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public abstract T Map(TSource source);

		/// <summary>
		/// Handles mapping a collection of model items.
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public IEnumerable<T> MapCollection(IEnumerable<TSource> source)
		{
			return (from d in source select this.Map(d)).ToList<T>();
		}

		#endregion
		
	}
}
