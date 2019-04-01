using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Model.Collections
{
    public class VitalsCollection: ObservableCollection<Vital>
    {
        
        public VitalsCollection(IEnumerable<Vital> source)
            :base(source)
        { }
        public VitalsCollection()
            :base()
        { }
    }
}
