using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using SR = Infragistics.Guidance.Aqua.DataCommon.EntityData;

namespace Infragistics.Guidance.Aqua.DataClient.Data.EntityMappers
{
	public class MedicationMapperEF : BaseDataMapper<Med, SR.Med>
	{
		
		#region Overridden Methods
				
		/// <summary>
		/// Handles mapping a single model item
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public override Med Map(SR.Med source)
		{
			return new Med
			{
				ID = source.ID,
				Name = source.Name
			};
		}

		#endregion
	}
}
