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
using Infragistics.Windows.DataPresenter;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Model;
using System.Windows.Threading;
using System.Diagnostics;
using Infragistics.Windows.Controls;
using Infragistics.Windows.TilePanel;


namespace Infragistics.Guidance.Aqua.Client.View
{
	/// <summary>
	/// Interaction logic for TestResultsView.xaml
	/// </summary>
	public partial class TestResultsView : UserControl
	{
		TestResultsViewModel viewModel = null;
		public TestResultsView()
		{
			InitializeComponent();
			this.Loaded += new RoutedEventHandler(TestResultsView_Loaded);
		}

		#region Event Handlers
		void TestResultsView_Loaded(object sender, RoutedEventArgs e)
		{
			this.viewModel = this.DataContext as TestResultsViewModel;
			if (this.viewModel != null)
			{
				this.viewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(trvm_PropertyChanged);
				SetUpGrid();
			}

			// Set Initial RadiologyTest Selection
			if (this.viewModel.RadiologyTests.Count > 0)
			{
				this.viewModel.SelectedRadiologyTest = this.viewModel.RadiologyTests[0];
			}
		}

		void trvm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "AllLabTests")
			{
				Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(SetUpGrid));
				//this.xdgTests.UpdateLayout();
				//SetUpGrid();
			}
			if (e.PropertyName == "WorkSpaceItemState")
			{
				if (this.viewModel.WorkSpaceItemState == WorkspaceItemState.MinimizedCollapsed)
				{
					this.viewModel.StopEKGTimer();
				}
				else
				{
					if (((TabItemEx)XamTabTestResults.SelectedItem).Header.ToString() == "Cardiology")
					{
						this.viewModel.StartEKGTimer();
					}

				}
			}
		}

		private void XamTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			TabItemEx tabItem = e.AddedItems[0] as TabItemEx;
			if (this.viewModel != null)
			{
				if (tabItem.Header.ToString() == "Cardiology")
				{
					this.viewModel.StartEKGTimer();
				}
				else
				{
					this.viewModel.StopEKGTimer();
				}
			}
		}

		private void btnNavigatePrev_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			XCLBRadiology.ScrollInfo.LineLeft();
		}

		private void btnNavigateNext_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			XCLBRadiology.ScrollInfo.LineRight();
		}

		#endregion Event Handlers

		#region Private Methods
		void SetUpGrid()
		{
			for (int i = this.xdgTests.FieldLayouts[0].Fields.Count - 1; i >= 0; i--)
			{
				if (this.xdgTests.FieldLayouts[0].Fields[i].IsUnbound)
					this.xdgTests.FieldLayouts[0].Fields.Remove(this.xdgTests.FieldLayouts[0].Fields[i]);

			}
			GenerateGridFields(this.viewModel.LabTimeStamps);
			FillGridWithLabTestValues();
		}

		public void GenerateGridFields(List<DateTime> timeStamps)
		{
			foreach (DateTime dt in timeStamps)
			{
				UnboundField field = new UnboundField();
				field.Name = dt.ToString();
                field.Label = string.Format("{0}/{1}-{2}", dt.Month.ToString(), dt.Day.ToString(), dt.ToShortTimeString());
				this.xdgTests.FieldLayouts[0].Fields.Add(field);
			}
		}

		public void FillGridWithLabTestValues()
		{
			foreach (Test test in this.viewModel.AllLabTests)
			{
				string TestName = test.TestType.Name;
				foreach (Record rec in xdgTests.Records)
				{
					DataRecord dr = rec as DataRecord;
					if (dr.Cells["Type"].Value.ToString() == TestName)
					{
						dr.Cells[test.Timestamp.ToString()].Value = test.Result;
						break;
					}
				}
			}
		}
		#endregion Private Methods

	}
}
