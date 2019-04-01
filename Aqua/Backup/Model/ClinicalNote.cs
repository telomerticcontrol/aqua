using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.Model
{
    public class ClinicalNote : BaseModel
    {

        #region Properties
        public int ID { get; set; }
        public int AdmittanceID { get; set; }
        public int ClinicalNoteTypeID { get; set; }
        public string Note { get; set; }
        public DateTime Timestamp { get; set; }
        public ClinicalNoteType ClinicalNoteType { get; set; }
        #endregion
        
    }
}
