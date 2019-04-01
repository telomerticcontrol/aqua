using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Model.Collections;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.Model
{
	public class Patient : BaseModel
    {
		public Patient()
		{
        }

        #region Properties
        public int PatientID { get; set; }        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public bool DNR { get; set; }
        public bool VIP { get; set; }
        public bool Infectious { get; set; }
        public AdmittanceCollection Admittances { get; set; }
        public AllergyCollection Allergies { get; set; }
        #endregion
    }
}
