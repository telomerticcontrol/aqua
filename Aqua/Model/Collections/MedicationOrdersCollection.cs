using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;

namespace Infragistics.Guidance.Aqua.Model.Collections
{
    public class MedicationOrdersCollection: ObservableCollection<Order>
    {
        public MedicationOrdersCollection(IEnumerable<Order> source)
            : base(source)
        { }
        public MedicationOrdersCollection()
            : base()
        { }

        #region Properties
        public BindingList<Order> AsBindingList
        {
            get { return CreateBindingList(); }
        }
        #endregion
        #region Methods
        private BindingList<Order> CreateBindingList()
        {
            BindingList<Order> OrdersBindingList = new BindingList<Order>();
            IEnumerator<Order> e = this.GetEnumerator();
            while (e.MoveNext())
            {
                OrdersBindingList.Add(e.Current);
            }
            return OrdersBindingList;
        }
        #endregion
    }
}
