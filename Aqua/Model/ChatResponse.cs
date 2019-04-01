using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infragistics.Guidance.Aqua.Model
{
    public class ChatResponse
    {
        #region Properties
        public int ID {get; set; }
        public string Response {get; set; }
        public ChatRole ChatRole { get; set; }
        #endregion
    }
}
