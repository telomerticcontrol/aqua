using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Infragistics.Windows.Editors;
using Infragistics.Guidance.Aqua.Client.ViewModel;

namespace Infragistics.Guidance.Aqua.Client.View
{
    /// <summary>
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        public OrdersView()
        {
            InitializeComponent();
            this.xdgOrders.FieldLayoutInitialized += new EventHandler<Infragistics.Windows.DataPresenter.Events.FieldLayoutInitializedEventArgs>(xdgOrders_FieldLayoutInitialized);
        }

        void xdgOrders_FieldLayoutInitialized(object sender, Infragistics.Windows.DataPresenter.Events.FieldLayoutInitializedEventArgs e)
        {
            ComboBoxItemsProvider MedicationsProvider = this.TryFindResource("MedicationLookUp") as ComboBoxItemsProvider;
            MedicationsProvider.ItemsSource = ((OrdersViewModel)this.DataContext).AllMedications;
        }
    }
}
