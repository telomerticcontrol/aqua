using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Infragistics.Guidance.Aqua.Model.Collections;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.Model
{
	public class Admittance : BaseModel
    {
		public Admittance()
		{
        }

        #region Properties
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int StaffAttendingID { get; set; }
        public int StaffRNID { get; set; }
        public string Comments { get; set; }
        public DateTime TimestampIn { get; set; }
        public DateTime TimestampOut { get; set; }
        public string Location { get; set; }
        public string Severity { get; set; }
        public string Disposition { get; set; }
        public string Diagnosis { get; set; }
        public string ReleaseNotes { get; set; }
        public ClinicalNotesCollection ClinicalNotes { get; set; }
        public HospitalStaffCollection HospitalStaff { get; set; }
        public Patient EDPatient { get; set; }
        public Complaint Complaints { get; set; }
        public MedicationOrdersCollection Orders { get; set; }
        public TestCollection Tests { get; set; }
        public VitalsCollection Vitals { get; set; }
        public Staff Attending
        {
            get { return this.HospitalStaff[0]; }
        }
        public Staff Nurse
        {
            get { return this.HospitalStaff[0]; }
        }
        public bool IsDataLoaded
        {
            get
            {
                return this.ClinicalNotes != null
                    && this.Complaints != null
                    && this.EDPatient != null
                    && this.HospitalStaff != null
                    && this.Orders != null
                    && this.Tests != null;
            }
        }
        #endregion
	
    }
    
}
