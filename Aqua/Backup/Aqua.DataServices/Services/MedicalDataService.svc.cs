using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using Infragistics.Guidance.Aqua.DataCommon.EntityData;

namespace Infragistics.Guidance.Aqua.DataServices.Services
{
	/// <summary>
	/// This class is the service end point for ADO.NET Data Services.
	/// </summary>
    public class MedicalDataService : DataService<MedicalDataEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(IDataServiceConfiguration config)
        {
			// Turn verbose logging on to get better errors returned
			config.UseVerboseErrors = true;

			// Configure the access rights for the entities exposed by ADO.NET DS
			config.SetEntitySetAccessRule("Admittance", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Allergy", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("BodyRegion", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ClinicalNote", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ClinicalNoteType", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Complaint", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ComplaintTestResult", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Admittance", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Med", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Order", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Patient", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("PatientAllergy", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Staff", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("StaffType", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Test", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("TestCategory", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("TestType", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Vital", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("VitalSignType", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ChatResponses", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("ChatRole", EntitySetRights.AllRead);

        }
    }
}
