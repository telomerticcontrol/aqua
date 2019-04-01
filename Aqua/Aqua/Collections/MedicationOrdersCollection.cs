using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;

namespace Infragistics.Guidance.Aqua.Client.Collections
{
    class MedicationOrdersCollection: ObservableCollection<Order>
    {
        IEnumerable<Order> source;
        public MedicationOrdersCollection(IEnumerable<Order> source)
        {
            this.source = source;
        }
        public MedicationOrdersCollection()
        { 
        
        }

        public BindingList<Order> AsBindingList
        {
            get { return CreateBindingList(source); }
        }

        private BindingList<Order> CreateBindingList(IEnumerable<Order> Orders)
        {
            BindingList<Order> OrdersBindingList = new BindingList<Order>();
            IEnumerator<Order> e = Orders.GetEnumerator();
            while (e.MoveNext())
            {
                OrdersBindingList.Add(e.Current);
            }
            return OrdersBindingList;
        }
    
    }
}
