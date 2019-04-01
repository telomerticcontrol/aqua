using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Framework;
using SR = Infragistics.Guidance.Aqua.DataCommon.EntityData;

namespace Infragistics.Guidance.Aqua.DataClient.Data.EntityMappers
{
	public class PatientMapperEF : BaseDataMapper<Patient, SR.Patient>
	{

		#region Overridden Methods

		/// <summary>
		/// Handles mapping a single model item
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public override Patient Map(SR.Patient source)
		{
			Patient patient = null;

			if (source != null)
			{
				CommandCriteria patientCriteria = new CommandCriteria();
				patientCriteria.Add("PatientId", source.ID.ToString());

				patient = new Patient()
				{
					PatientID = source.ID,
					FirstName = source.FirstName,
					LastName = source.LastName,
					MiddleName = source.MiddleName,
					DNR = (bool)source.DNR,
					Gender = source.Gender,
					DOB = source.DOB.ConvertToDateTime(),
					Infectious = (bool)source.Infectious,
					Suffix = source.Suffix,
					VIP = (bool)source.VIP
				};
			}
			return patient;
		}

		#endregion
	}
}
