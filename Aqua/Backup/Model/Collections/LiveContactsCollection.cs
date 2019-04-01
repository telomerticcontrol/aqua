using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.LiveFX.ResourceModel;
using Microsoft.LiveFX.Client;

namespace Infragistics.Guidance.Aqua.Client.Collections
{
    public class LiveContactsCollection: ObservableCollection<Contact>
    {
        public LiveContactsCollection(IEnumerable<Contact> source)
            :base(source)
        { }
        public LiveContactsCollection()
            : base()
        { }
        
    }
}
