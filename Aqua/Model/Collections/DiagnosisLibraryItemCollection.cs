using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Model.Collections
{
    public class DiagnosisLibraryItemCollection: ObservableCollection<DiagnosisLibraryItem>
    {
         public DiagnosisLibraryItemCollection(IEnumerable<DiagnosisLibraryItem> source)
            : base(source)
        { }
         public DiagnosisLibraryItemCollection()
            : base()
        { }
    }
}
