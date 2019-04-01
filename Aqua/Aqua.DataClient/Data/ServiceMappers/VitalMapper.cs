using System;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using SR = Infragistics.Guidance.Aqua.DataClient.MedicalService;

namespace Infragistics.Guidance.Aqua.DataClient.Data.ServiceMappers
{
	public class VitalMapper : BaseDataMapper<Vital, SR.Vital>
	{

		#region Overridden Methods

		/// <summary>
		/// Handles mapping a single model item
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public override Vital Map(SR.Vital source)
		{
			return new Vital
			{
				Value = source.VitalSignValue,
				Timestamp = source.Timestamp ?? DateTime.Parse("1/1/1900"),
                
                VitalSignType = new VitalSignType 
				{ 
					Name = source.VitalSignType.Name 
				
                }
			};
		}

		#endregion
	}
}
