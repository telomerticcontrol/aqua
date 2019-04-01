using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.Model
{
    public class DiagnosisLibraryItem : BaseModel
    {
        #region Properties
        public string ContentType {get; set;}
        public DateTime LastModifiedTime { get; set; }
        public string Name { get; set; }
        public Uri ItemUri { get; set; }
        #endregion
    }
}
