using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Client.Collections
{
    class VitalsCollection: ObservableCollection<Vital>
    {
        public VitalsCollection(IEnumerable<Vital> source)
        { 
        
        }
        public VitalsCollection()
        { }
    }
}
