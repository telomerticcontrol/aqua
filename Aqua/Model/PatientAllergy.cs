using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.Model
{
	public class PatientAllergy : BaseModel
    {
        #region Properties
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int AllergyID { get; set; }
        public Allergy Allergy { get; set; }
        #endregion
    }
}
