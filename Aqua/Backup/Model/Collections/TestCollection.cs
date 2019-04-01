using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Model.Collections
{
    public class TestCollection: ObservableCollection<Test>
    {
        public TestCollection(IEnumerable<Test> source)
            :base(source)
        { }
        public TestCollection()
            :base()
        { }
    }
}
