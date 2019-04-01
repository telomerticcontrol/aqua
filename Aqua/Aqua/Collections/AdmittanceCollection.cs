using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Client.Collections
{
    class AdmittanceCollection: ObservableCollection<Admittance>
    {
        public AdmittanceCollection(IEnumerable<Admittance> source)
        { 
        
        }
        public AdmittanceCollection()
        { 
        
        }
    }
}
