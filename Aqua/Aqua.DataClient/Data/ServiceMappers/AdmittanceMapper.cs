using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Framework;
using SR = Infragistics.Guidance.Aqua.DataClient.MedicalService;

namespace Infragistics.Guidance.Aqua.DataClient.Data.ServiceMappers
{
	public class AdmittanceMapper : BaseDataMapper<Admittance, SR.Admittance>
	{

		#region Fields

		PatientMapper patientMapper;
		StaffMapper staffMapper;
		ComplaintMapper complaintMapper;
		TestMapper testMapper;

		#endregion

		#region Constructors

		/// <summary>
		/// Default Constructor for the Mapper
		/// </summary>
		/// <remarks>Creates depend mappers</remarks>
		public AdmittanceMapper()
		{
			this.patientMapper = new PatientMapper();
			this.staffMapper = new StaffMapper();
			this.complaintMapper = new ComplaintMapper();
			this.testMapper = new TestMapper();
		}

		#endregion

		#region Overridden Methods
			
		/// <summary>
		/// Handles mapping a single model item
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public override Admittance Map(SR.Admittance source)
		{
			CommandCriteria patientCriteria = new CommandCriteria();
			patientCriteria.Add("AdmittanceId", source.ID.ToString());

			return new Admittance()
						{
							ID = source.ID,
							Severity = source.Severity,
							TimestampIn = source.TimestampIn.ConvertToDateTime(),
							TimestampOut = source.TimestampOut.ConvertToDateTime(),
							Comments = source.Comments,
							Diagnosis = source.Diagnosis,
							Location = source.Location,
							Disposition = source.Disposition,
							EDPatient = this.patientMapper.Map(source.Patient),
							HospitalStaff = this.staffMapper.MapToCollection(source.Staff),
							Complaints = this.complaintMapper.MapToCollection(source.Complaints),
                            
                        };

		}

		#endregion


	}
}
