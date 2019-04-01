using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Client.ViewModel;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Client.Collections
{
    public class TestResultViewModelCollection:ObservableCollection<TestResultViewModel>
    {
        public TestResultViewModelCollection(IEnumerable<TestResultViewModel> source)
            : base(source)
        { }
        public TestResultViewModelCollection()
            : base()
        { }
    }
}
