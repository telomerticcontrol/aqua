using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.Model
{
	public class Test : BaseModel
    {
        #region Properties
        public int ID { get; set; }
        public int TestTypeID { get; set; }
        public int AdmittanceID { get; set; }
        public DateTime Timestamp { get; set; }
        public string Result { get; set; }
        public int BodyRegionID { get; set; }
        public TestType TestType { get; set; }
        public Admittance Admittance { get; set; }
        public BodyRegion BodyRegion { get; set; }
        public bool IsLabTest
        {
            get
            {
                return this.TestType != null
                    && this.TestType.CompareTestCategory("Lab");
            }
        }
        public bool IsRadiologyTest
        {
            get
            {
                return this.TestType != null
                    && this.TestType.CompareTestCategory("Radiology");
            }
        }
        #endregion

    }
}
