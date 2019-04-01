using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Client.ViewModel;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Client.Collections
{
    public class PatientRecordItemsViewModelCollection: ObservableCollection<PatientRecordItemsViewModel>
    {
        public PatientRecordItemsViewModelCollection(IEnumerable<PatientRecordItemsViewModel> source)
            : base(source)
        { }
        public PatientRecordItemsViewModelCollection()
            : base()
        { }
        
    }
}
