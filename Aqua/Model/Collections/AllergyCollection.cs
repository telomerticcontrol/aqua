using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Model.Collections
{
    public class AllergyCollection : ObservableCollection<PatientAllergy>
    {
        public AllergyCollection(IEnumerable<PatientAllergy> source)
            : base(source)
        { }
        public AllergyCollection()
            : base()
        { }
    }
}
