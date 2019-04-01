using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Windows.TilePanel;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Model;
using System.Data;
using Infragistics.Guidance.Aqua.Model.Collections;
using Infragistics.Guidance.Aqua.Client.Collections;
using System.Windows.Forms;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
    public class TestResultsViewModel:ViewModelBase
    {
        public TestResultsViewModel(MainWindowViewModel owner)
        {
            this.mainWindowViewModel = owner;
            this.mainWindowViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(mainWindowViewModel_PropertyChanged);
            ekgCount = ekgValues.Length;
            EKGDataView = GetEKGData();
            EKGTimer = new Timer();
            EKGTimer.Interval = 32;
            EKGTimer.Tick += new EventHandler(EKGTimer_Tick);
        }
        
        #region Fields
        private MainWindowViewModel mainWindowViewModel;
        private TestCollection tests = null;
        private WorkspaceItemState workSpaceItemState;
        private object[] ekgValues = { 0, 0, 2, 4, 6, 5.25, 3.75, 1.5, 0, 0, -2.33, -4.66, -7, 8, 23, 38, 53, 36, 19, 2, -15, -12, -9, -6, -3, 0, 0, 3.8, 5.7, 9.5, 5.91, 3.51, 0, 0, 2, 4, 6, 5.25, 3.75, 1.5, 0, 0, -2.33, -4.66, -7, 8, 23, 38, 53, 36, 19, 2, -15, -12, -9, -6, -3, 0, 0, 3.8, 5.7, 9.5, 5.91, 3.51, };
        private int ekgCount = 0;
        private DataView EKGDataView;
        private Timer EKGTimer;
        private int counter = 0;
        private TestResultViewModel selectedRadiologyTest;
        private TestCollection distinctTests;
        private TestResultViewModelCollection radiologyTests = new TestResultViewModelCollection();
        private TestResultViewModelCollection distinctLabTests = new TestResultViewModelCollection();
        private List<DateTime> labTimeStamps;
        private TestCollection allLabTests = new TestCollection();
        
        #endregion

        #region Event Handlers
        void mainWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedPatient")
            {

                this.OnPropertyChanged("DistinctLabTests");
                this.OnPropertyChanged("AllLabTests");
                this.OnPropertyChanged("LabTimeStamps");
                this.OnPropertyChanged("DistinctTests");
                this.OnPropertyChanged("RadiologyTests");
                EKGDataView.Table.Rows.Clear();
                counter = 0;
            }
        }
        void EKGTimer_Tick(object sender, EventArgs e)
        {

            if (counter >= ekgCount)
            {
                this.EKGDataView.Table.Rows.Add(new object[] { this.EKGDataView.Table.Rows[0][0].ToString() });
                this.EKGDataView.Table.Rows.RemoveAt(0);
            }
            else
            {
                this.EKGDataView.Table.Rows.Add(ekgValues[counter]);
                counter++;
            }
            OnPropertyChanged("EKGData");

        }
        #endregion

        #region Properties
        public TestCollection Tests
        {
            get
            {
                if (this.mainWindowViewModel.SelectedPatient != null)
                {
                    if (this.tests == null)
                    {
                        this.tests = this.mainWindowViewModel.SelectedPatient.Tests;
                        return this.tests;
                    }
                    return this.tests;
                }
                return null;
            }

        }

        public TestCollection DistinctTests
        {
            get
            {
                if (this.mainWindowViewModel.SelectedPatient != null)
                {
                    if (this.distinctTests == null)
                    {
                        GetDistinctTests(this.Tests);
                    }
                    return this.distinctTests;
                }
                return null;
            }
        }
        public TestResultViewModelCollection RadiologyTests
        {
            get
            {
                if (this.mainWindowViewModel.SelectedPatient != null)
                {
                    GetDistinctRadiologyTests(this.mainWindowViewModel.SelectedPatient.Tests);
                }
                return this.radiologyTests;
            }
        }


        public TestResultViewModel SelectedRadiologyTest
        {
            get
            {
                return this.selectedRadiologyTest;
            }
            set
            {
                this.selectedRadiologyTest = value as TestResultViewModel;
                this.OnPropertyChanged("SelectedRadiologyTest");
            }
        }
        public TestCollection AllLabTests
        {
            get
            {
                if (this.mainWindowViewModel.SelectedPatient != null)
                {
                    GetAllLabTests(this.mainWindowViewModel.SelectedPatient.Tests);
                }
                return this.allLabTests;
            }
        }


        public TestResultViewModelCollection DistinctLabTests
        {
            get
            {
                if (this.mainWindowViewModel.SelectedPatient != null)
                {
                    GetDistinctLabTests(this.AllLabTests);
                }
                return this.distinctLabTests;
            }
        }
        public List<DateTime> LabTimeStamps
        {
            get
            {
                GetDistinctLabTimeStamps(this.allLabTests);
                return this.labTimeStamps;
            }
        }
        public void StartEKGTimer()
        {
            EKGTimer.Start();
        }

        public void StopEKGTimer()
        {
            EKGTimer.Stop();
        }
        public Timer Timer
        {
            get { return this.EKGTimer; }
        }
        public WorkspaceItemState WorkSpaceItemState
        {
            get { return this.workSpaceItemState; }
            set
            {
                this.workSpaceItemState = value;
                OnPropertyChanged("WorkSpaceItemState");
            }
        }

        public DataView EKGData
        {
            get
            {

                EKGTimer.Start();
                return this.EKGDataView;
            }
        }
        #endregion

        #region Private Methods
        private void GetDistinctTests(TestCollection Tests)
        {

            var distinctTests = (from t in Tests select t).Distinct(new TestTypeComparer());
            this.distinctTests = new TestCollection(distinctTests);
        }

        private void GetDistinctRadiologyTests(TestCollection Tests)
        {
            var distinctRadiologyTests = (from t in Tests where t.IsRadiologyTest select t);
            distinctRadiologyTests.ToList();
            this.radiologyTests = new TestResultViewModelCollection();
            foreach (Test t in distinctRadiologyTests)
            {
                TestResultViewModel testResultViewModel = new TestResultViewModel(this.mainWindowViewModel.SelectedPatient.Admittance, t);

                this.radiologyTests.Add(testResultViewModel);
            }
        }

        private void GetAllLabTests(TestCollection Tests)
        {
            if (Tests != null)
            {
                var allLabTests = (from t in Tests where t.IsLabTest select t);
                this.allLabTests = new TestCollection(allLabTests);
            }
            else
            {
                this.allLabTests = new TestCollection();
            }
        }

        private void GetDistinctLabTests(TestCollection Tests)
        {
            //I need to distinctly compare test type names.  This is different then the others.  The cardio and radio
            //collections need only be distinct by test type.  This is being used to give me my rows so I have to 
            //base the collection just on testtype so the custom comparer is used rather then a where clause.
            var distinctLabTests = (from t in Tests select t).Distinct(new TestTypeComparer());
            distinctLabTests.ToList();
            this.distinctLabTests = new TestResultViewModelCollection();
            foreach (Test t in distinctLabTests)
            {
                TestResultViewModel testResultViewModel = new TestResultViewModel(this.mainWindowViewModel.SelectedPatient.Admittance, t);
                this.distinctLabTests.Add(testResultViewModel);
            }
        }

        private void GetDistinctLabTimeStamps(TestCollection Tests)
        {
            var distinctLabTimeStamps = (from t in Tests select t.Timestamp).Distinct();
            this.labTimeStamps = distinctLabTimeStamps.ToList();
        }

        private DataView GetEKGData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EKGValues", typeof(double));
            return dt.DefaultView;
        }

        #endregion

        
    }
    
    public class TestTypeComparer : IEqualityComparer<Test>
    {

        #region IEqualityComparer<Test> Members

        public bool Equals(Test x, Test y)
        {
            return (x.TestType.Name == y.TestType.Name);
        }

        public int GetHashCode(Test obj)
        {
            return obj.ToString().GetHashCode();
        }

        #endregion
    }
}
