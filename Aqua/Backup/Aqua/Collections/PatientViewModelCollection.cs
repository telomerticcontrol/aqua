using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Client.ViewModel;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Client.Collections
{
    public class PatientViewModelCollection: ObservableCollection<PatientViewModel>
    {
        public PatientViewModelCollection(IEnumerable<PatientViewModel> source)
            : base(source)
        { }
        public PatientViewModelCollection()
            : base()
        { }
    }
}
