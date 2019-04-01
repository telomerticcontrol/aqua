using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using SR = Infragistics.Guidance.Aqua.DataCommon.EntityData;

namespace Infragistics.Guidance.Aqua.DataClient.Data.EntityMappers
{
	public class OrderMapperEF : BaseDataMapper<Order, SR.Order>
	{

		#region Overridden Methods

		/// <summary>
		/// Handles mapping a single model item
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public override Order Map(SR.Order source)
		{
			return new Order
			{
				Dosage = source.Dosage.GetValueOrDefault(),
				Frequency = source.Frequency,
				Indication = source.Indication,
				Unit = source.Unit,
				Medication = new Med 
				{ 
					ID = source.Med.ID, 
					Name = source.Med.Name
				}
			};
		}


		#endregion
	}
}
