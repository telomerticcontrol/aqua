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
using Infragistics.Guidance.Aqua.Client.ViewModel;

namespace Infragistics.Guidance.Aqua.Client.View
{
    /// <summary>
    /// Interaction logic for PhysicianBannerView.xaml
    /// </summary>
    public partial class PhysicianBannerView : UserControl
    {
        public PhysicianBannerView()
        {
            InitializeComponent();
        }

		void xcePatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MainWindowViewModel _owner = this.DataContext as MainWindowViewModel;
			if(e.AddedItems != null && e.AddedItems.Count > 0)
				_owner.SelectedPatient = e.AddedItems[0] as PatientViewModel;
		}

		//private void xcePatients_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		//{
		//    MainWindowViewModel _owner = this.DataContext as MainWindowViewModel;

		//    _owner.SelectedPatient =e.NewValue as PatientViewModel;
		//}
    }
}
