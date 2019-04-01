using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using SR = Infragistics.Guidance.Aqua.DataClient.MedicalService;

namespace Infragistics.Guidance.Aqua.DataClient.Data.ServiceMappers
{
	public class AllergyMapper : BaseDataMapper<PatientAllergy, SR.PatientAllergy>
	{

		#region Overridden Methods

		/// <summary>
		/// Handles mapping a single model item
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public override PatientAllergy Map(SR.PatientAllergy source)
		{
			return new PatientAllergy()
			{
				AllergyID = source.Allergy.ID,
				Allergy = new Allergy { Name = source.Allergy.Name }
			};
		}

		#endregion

	}
}
