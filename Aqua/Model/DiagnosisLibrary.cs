using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model.Framework;
using Infragistics.Guidance.Aqua.Model.Collections;

namespace Infragistics.Guidance.Aqua.Model
{
    public class DiagnosisLibrary :BaseModel
    {
        #region Properties
        public DiagnosisLibraryItemCollection LibraryItems { get; set; }
        #endregion
    }
}
