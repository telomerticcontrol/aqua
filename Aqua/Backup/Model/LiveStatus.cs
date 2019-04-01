using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model.Framework;
using Microsoft.LiveFX.Client;

namespace Infragistics.Guidance.Aqua.Model
{
    public class LiveStatus:BaseModel
    {
        #region Properties
        public LiveOperatingEnvironment LiveOperatingEnvironment { get; set; }
        public string Token { get; set; }
        public bool HasLoginErrors { get; set; }
        public string LoginErrorMessage { get; set; }
        #endregion
    }
}
