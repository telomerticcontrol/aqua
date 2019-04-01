using System;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Collections;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.DataClient.Commands
{
	public class ChangePatientCommand : BaseDataCommand<Patient>
	{

		#region Overridden Methods
		
		/// <summary>
		/// Logic for the Change Patient Command
		/// </summary>
		/// <param name="criteria">Criteria for the command</param>
		/// <returns>Result from executing the command</returns>
		/// <remarks>This command updates the admittance/patient object based in.</remarks>
		protected override object ProcessCommand(CommandCriteria criteria)
		{

			Patient patient = null;

			// Get the admittance from criteria - This will be the object that gets updated.
			Admittance admittance = criteria["Admittance"] as Admittance;

			if (admittance != null)
			{
               
				// Setup the criteria required by the repositories
				criteria.Add("PatientId", admittance.EDPatient.PatientID.ToString());
				criteria.Add("AdmittanceId", admittance.ID.ToString());

				// Get the Repository Provider
				IRepositoryProvider factory = DIManager.Current.Get<IRepositoryProvider>();


				// Load the patient related data
				patient = admittance.EDPatient;

				patient.Admittances =
					new AdmittanceCollection(
						factory.GetRepository<Admittance>("AdmittanceRepository").SelectCollection(criteria));
				patient.Allergies = 
				    new AllergyCollection(
						factory.GetRepository<PatientAllergy>("AlleryRepository").SelectCollection(criteria));

				// Load the admittance related data
				admittance.Orders =
				    new MedicationOrdersCollection(
						factory.GetRepository<Order>("OrderRepository").SelectCollection(criteria));

				admittance.Tests = 
				    new TestCollection(
						factory.GetRepository<Test>("TestRepository").SelectCollection(criteria));

				admittance.Vitals = 
				    new VitalsCollection(
						factory.GetRepository<Vital>("VitalRepository").SelectCollection(criteria));

				admittance.ClinicalNotes =
					new ClinicalNotesCollection(
						factory.GetRepository<ClinicalNote>("ClinicalNoteRepository").SelectCollection(criteria));
				   
				this.GetAdmittanceHistoryTests(factory, patient.Admittances, admittance.EDPatient.PatientID.ToString());
            }
			else
			{
				// If an admittance is not based in notify the caller
				throw new ApplicationException("Command requires a criteria parameter called Admittance.");
			}
			
			return patient;
		}
		
		#endregion
		
		#region Private Methods

		/// <summary>
		/// Retrieve the test data for the patient's admittance history
		/// </summary>
		/// <param name="admittances">Patient Admittance history</param>
		/// <param name="patientId">Patient ID</param>
		/// <returns>Admittance History with test results data</returns>
		private AdmittanceCollection GetAdmittanceHistoryTests(IRepositoryProvider factory, AdmittanceCollection admittances, string patientId)
		{
            
			AdmittanceCollection admittanceHistory = admittances;

			// factory.Get<IRepository<Test>>("TestRepository");
			IRepository<Test> testRepository = factory.GetRepository<Test>("TestRepository");
			IRepository<ClinicalNote> clinicalNoteRepository = factory.GetRepository<ClinicalNote>("ClinicalNoteRepository");
				
	
			foreach (Admittance admittance in admittanceHistory)
			{
				CommandCriteria criteria = new CommandCriteria();
				criteria.Add("PatientId", patientId);
				criteria.Add("AdmittanceId", admittance.ID.ToString());
				admittance.Tests =
					new TestCollection(testRepository.SelectCollection(criteria));
				admittance.ClinicalNotes =
					new ClinicalNotesCollection(clinicalNoteRepository.SelectCollection(criteria));
            }

			return admittanceHistory;
		}
       
		#endregion
		
	}
}
