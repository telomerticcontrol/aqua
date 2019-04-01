using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Model.Collections
{
    public class ClinicalNotesCollection: ObservableCollection<ClinicalNote>
    {
        public ClinicalNotesCollection(IEnumerable<ClinicalNote> source)
            : base(source)
        { }
        public ClinicalNotesCollection()
            : base()
        { }
    }
}
