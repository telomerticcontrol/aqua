using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;

namespace Infragistics.Guidance.Aqua.Model.Collections
{
    public class HospitalStaffCollection: ObservableCollection<Staff>
    {
        public HospitalStaffCollection(IEnumerable<Staff> source)
            : base(source)
        { }
        public HospitalStaffCollection()
            :base()
        { }
    }
}
