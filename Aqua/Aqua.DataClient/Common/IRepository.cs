using System.Collections.Generic;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.DataClient.Common
{
	public interface IRepository<T>
	{
		T Select(CommandCriteria criteria);

		IEnumerable<T> SelectCollection(CommandCriteria criteria);

	}
}
