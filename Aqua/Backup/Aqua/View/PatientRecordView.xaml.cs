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
using Infragistics.Silverlight.Timeline;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Client.Collections;

namespace Infragistics.Guidance.Aqua.Client.View
{
	/// <summary>
	/// Interaction logic for PatientRecordView.xaml
	/// </summary>
	public partial class PatientRecordView : UserControl
	{
		PatientRecordViewModel patientRecordViewModel;
		public PatientRecordView()
		{
			InitializeComponent();

			this.Loaded += new RoutedEventHandler(PatientRecordView_Loaded);
			this.AdmittanceDateLB.SelectionChanged += new SelectionChangedEventHandler(AdmittanceDateLB_SelectionChanged);     
		}

        

		#region Event Handlers
        void patientRecordViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AdmittanceRecord")
            {
                ClearBodyRegions();
            }
        }
		void PatientRecordView_Loaded(object sender, RoutedEventArgs e)
		{
			// Initialize Selection
			this.patientRecordViewModel = this.DataContext as PatientRecordViewModel;
            patientRecordViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(patientRecordViewModel_PropertyChanged);
		}

		#region Buttons
		private void btnNavigatePrev_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			ImageCarousel.ScrollInfo.LineLeft();
		}

		private void btnNavigateNext_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			ImageCarousel.ScrollInfo.LineRight();
		}
		#endregion Buttons

		#region Date Listbox
		void AdmittanceDateLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ClearBodyRegions();
			this.patientRecordViewModel.SelectedRecord.SetUpBodyRegions();
		}
		#endregion Date Listbox

		#region Body Parts
		private void BodyRegionChanged(object sender, RoutedEventArgs e)
		{
			RadioButton BodyRegionRadioButton = sender as RadioButton;
			string BodyRegion = BodyRegionRadioButton.Name.Remove(0, 10);
			IEnumerable<TestResultViewModel> images;
			images = (this.patientRecordViewModel.SelectedRecord.ImageTests as TestResultViewModelCollection).Where(test => test.BodyRegion.Name == BodyRegion);

			if (images != null)
			{
				TestResultViewModelCollection imageTests = new TestResultViewModelCollection();
				foreach (TestResultViewModel test in images)
				{
					imageTests.Add(test);
				}
				this.ImageCarousel.ItemsSource = imageTests;
			}
		}
		#endregion Body Parts

		#region Timeline
		private void TimeLineLoaded(object sender, RoutedEventArgs e)
		{
			Binding TimeLineBinding = new Binding("AdmittanceRecord");
			TimeLineBinding.Source = this.DataContext;
			timeline1.Series[0].SetBinding(DateTimeSeries.DataSourceProperty, TimeLineBinding);
			timeline1.Series[0].DataMapping = "Time=AdmittanceDate;Title=ThisPatientRecordItem";
		}
		#endregion Timeline

		#endregion Event Handlers

		#region Private Methods
		private void ClearBodyRegions()
		{
			this.BodyRegionHead.IsChecked = false;
            this.BodyRegionTorso.IsChecked = false;
            this.BodyRegionLeftArm.IsChecked = false;
            this.BodyRegionLeftLeg.IsChecked = false;    
            this.BodyRegionRightArm.IsChecked = false;
            this.BodyRegionRightLeg.IsChecked = false;            
		}				
		#endregion Private Methods

	}
}
