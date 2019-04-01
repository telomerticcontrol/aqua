using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.Model
{
	public class Vital : BaseModel
    {
        #region Properties
       
        public int ID { get; set; }
        public int VitalSignTypeID { get; set; }
        public int AdmittanceID { get; set; }
        public string Value { get; set; }
        public DateTime Timestamp { get; set; }
        public VitalSignType VitalSignType { get; set; }
        public int BPHigh
        {
            get
            {
                if (this.VitalSignType.Name == "Blood Pressure")
                {
                    return ParseBP(this.Value, "BPHigh");
                }
                return 0;
            }
           
        }
        public int BPLow
        {
            get
            {
                if (this.VitalSignType.Name == "Blood Pressure")
                {
                    return ParseBP(this.Value, "BPLow");
                }
                return 0;
            }

        }
        #endregion
        #region Methods
        private int ParseBP(string BPValue,string BPNumber)
        {
            string[] BPSplit;
            switch (BPNumber)
            { 
                case "BPHigh":
                {
                    BPSplit = BPValue.Split('/');
                    return Convert.ToInt32(BPSplit[0]);
                    break;
                }
                case "BPLow":
                {
                    BPSplit = BPValue.Split('/');
                    return Convert.ToInt32(BPSplit[1]);
                    break;
                }
                default:
                    {
                        return 0;
                        break;
                    }
                    
            }
        }
        #endregion
    }
}
