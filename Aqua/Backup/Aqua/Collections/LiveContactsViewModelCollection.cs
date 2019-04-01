using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Client.ViewModel;

namespace Infragistics.Guidance.Aqua.Client.Collections
{
    public class LiveContactsViewModelCollection: ObservableCollection<LiveContactViewModel>
    {
        public LiveContactsViewModelCollection(IEnumerable<LiveContactViewModel> source)
            : base(source)
        { }

        public LiveContactsViewModelCollection()
            : base()
        { }
    }
}
