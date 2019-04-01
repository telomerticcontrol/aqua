using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Model.Collections
{
    public class AdmittanceCollection: ObservableCollection<Admittance>
    {
        public AdmittanceCollection(IEnumerable<Admittance> source)
            : base(source)
        { }
        public AdmittanceCollection()
            : base()
        { }
    }
}
