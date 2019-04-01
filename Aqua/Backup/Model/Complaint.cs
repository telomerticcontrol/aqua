using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.Model
{
	public class Complaint : BaseModel
    {
        #region Properties
        public int ID { get; set; }
        public int AdmittanceID { get; set; }
        public string PatientComplaint { get; set; }
        #endregion
    }
}
