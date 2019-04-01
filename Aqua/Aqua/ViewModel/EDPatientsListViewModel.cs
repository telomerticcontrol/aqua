using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Infragistics.Windows.DataPresenter;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Client;
using System.Collections.ObjectModel;
using Infragistics.Windows.TilePanel;
using System.Data;
using System.Windows;
using Infragistics.Guidance.Aqua.Model.Collections;
using Infragistics.Guidance.Aqua.Client.Collections;
using System.Windows.Forms;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
    public class EDPatientsListViewModel : ViewModelBase
    {
        public EDPatientsListViewModel(MainWindowViewModel owner)
        {

            this.mainWindowViewModel = owner;
            this.mainWindowViewModel.PropertyChanged += new PropertyChangedEventHandler(mainWindowViewModel_PropertyChanged);
            this.selectedRecord = null;
            this.PropertyChanged += new PropertyChangedEventHandler(EDPatinetsListViewModel_PropertyChanged);
            ekgCount = ekgValues.Length;
            EKGDataView = GetEKGData();
            EKGTimer = new Timer();
            EKGTimer.Interval = 32;
            EKGTimer.Tick += new EventHandler(EKGTimer_Tick);
        }
      
        #region Fields
        private MainWindowViewModel mainWindowViewModel;
        private Record selectedRecord;
        private object[] ekgValues = { 0, 0, 2, 4, 6, 5.25, 3.75, 1.5, 0, 0, -2.33, -4.66, -7, 8, 23, 38, 53, 36, 19, 2, -15, -12, -9, -6, -3, 0, 0, 3.8, 5.7, 9.5, 5.91, 3.51, 0, 0, 2, 4, 6, 5.25, 3.75, 1.5, 0, 0, -2.33, -4.66, -7, 8, 23, 38, 53, 36, 19, 2, -15, -12, -9, -6, -3, 0, 0, 3.8, 5.7, 9.5, 5.91, 3.51, };
        private int ekgCount = 0;
        private DataView EKGDataView;
        private Timer EKGTimer;
        private int counter = 0;
        private Record selectedRecordFullScreen;
        private WorkspaceItemState workSpaceItemState;
        #endregion
        #region Properties
        public Record SelectedRecord
        {
            get { return this.selectedRecord; }
            set
            {
                this.selectedRecord = value;
                if (this.selectedRecord != null)
                    this.mainWindowViewModel.SelectedPatient = (this.selectedRecord as DataRecord).DataItem as PatientViewModel;

                else
                    this.mainWindowViewModel.SelectedPatient = null;

                OnPropertyChanged("SelectedRecord");
            }
        }


        public Record FullScreenSelectedRecord
        {
            get { return this.selectedRecordFullScreen; }
            set
            {
                this.selectedRecordFullScreen = value;
                if (this.selectedRecordFullScreen != null)
                    this.mainWindowViewModel.SelectedPatient = (this.selectedRecordFullScreen as DataRecord).DataItem as PatientViewModel;

                else
                    this.mainWindowViewModel.SelectedPatient = null;

                OnPropertyChanged("FullScreenSelectedRecord");
            }
        }
        public AdmittanceCollection HospitalAdmittants
        {
            get { return this.mainWindowViewModel.HospitalAdmittants; }
        }
        public PatientViewModelCollection PatientList
        {
            get { return this.mainWindowViewModel.PatientList; }
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

        public Visibility xdgEDPatientsListNormal
        {
            get
            {
                if (this.WorkSpaceItemState != WorkspaceItemState.Maximized)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }

        public Visibility xdgEDPatientsListMaximized
        {
            get
            {
                if (this.WorkSpaceItemState == WorkspaceItemState.Maximized)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }
        public Visibility xdgVitalsMaximized
        {
            get
            {
                if (this.WorkSpaceItemState == WorkspaceItemState.Maximized)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }
        public Visibility XCVitalsMaximized
        {
            get
            {
                if (this.WorkSpaceItemState == WorkspaceItemState.Maximized)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }

        public VitalsCollection Vitals
        {
            get
            {
                if (this.mainWindowViewModel.SelectedPatient != null)
                {
                    return this.mainWindowViewModel.SelectedPatient.Vitals;
                }
                return null;
            }
        }
        public MedicationOrdersCollection MedicationOrders
        {
            get
            {
                if (this.mainWindowViewModel.SelectedPatient != null)
                {
                    return this.mainWindowViewModel.SelectedPatient.Orders;
                }
                return null;
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
        #region Methods
        public void StartEKGTimer()
        {
            EKGTimer.Start();
        }

        public void StopEKGTimer()
        {
            EKGTimer.Stop();
        }
        public DataView GetEKGData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EKGValues", typeof(double));
            return dt.DefaultView;

        }
        public Record GetRecordFromDataItem(PatientViewModel selectedPatient, Record selectedRecord)
        {
            Record record = null;

            if (this.SelectedRecord != null && selectedPatient != null)
            {
                record = (from r in selectedRecord.DataPresenter.Records
                          where ((PatientViewModel)((DataRecord)r).DataItem).Admittance.ID == selectedPatient.Admittance.ID
                          select r).SingleOrDefault();

            }

            return record;
        }
        #endregion
        #region Event Handlers

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

        void EDPatinetsListViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "WorkSpaceItemState")
            {
                OnPropertyChanged("xdgEDPatientsListNormal");
                OnPropertyChanged("xdgEDPatientsListMaximized");
                OnPropertyChanged("xdgVitalsMaximized");
                OnPropertyChanged("XCVitalsMaximized");
            }
        }

        void mainWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedPatient")
            {
				if (SelectedRecord != null)
				{
					SelectedRecord.DataPresenter.ActiveRecord = this.GetRecordFromDataItem(this.mainWindowViewModel.SelectedPatient, SelectedRecord);
				}

                if (this.FullScreenSelectedRecord != null)
                {
                    FullScreenSelectedRecord.DataPresenter.ActiveRecord = GetRecordFromDataItem(this.mainWindowViewModel.SelectedPatient, FullScreenSelectedRecord) as Record;
                }
                this.OnPropertyChanged("SelectedRecord");
                this.OnPropertyChanged("FullScreenSelectedRecord");
                this.OnPropertyChanged("MedicationOrders");
                this.OnPropertyChanged("Vitals");               
            }
        }

        #endregion
    }
}
