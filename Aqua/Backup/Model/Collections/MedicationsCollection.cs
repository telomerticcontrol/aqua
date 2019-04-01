using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Model.Collections
{
    public class MedicationsCollection: ObservableCollection<Med>
    {
        public MedicationsCollection(IEnumerable<Med> source)
            : base(source)
        { }

        public MedicationsCollection()
            : base()
        { }
    }  
}
