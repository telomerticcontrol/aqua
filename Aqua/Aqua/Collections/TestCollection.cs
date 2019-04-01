using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Client.Collections
{
    class TestCollection: ObservableCollection<Test>
    {
        public TestCollection(IEnumerable<Test> source)
        {
            IEnumerator<Test> e = source.GetEnumerator();
            while (e.MoveNext())
            {
                this.Items.Add(e.Current);
            }
        }
        public TestCollection()
        { }
    }
}
