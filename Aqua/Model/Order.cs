using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.Model
{
	public class Order : BaseModel
    {
        #region Properties
        public int ID { get; set; }
        public int AdmittanceID { get; set; }
        public int Dosage { get; set; } 
        public DateTime Timestamp { get; set; }
        public string Unit {get;set;}
        public string Frequency {get;set;}
        public string Indication {get;set;}
        public Med Medication { get; set; } 
		public int MedID
		{
			get
			{
				return this.Medication.ID;
			}
        }
        #endregion
    }
}
