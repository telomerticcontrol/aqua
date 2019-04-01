using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Windows.TilePanel;
using System.Data;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using System.Windows;
using Infragistics.Guidance.Aqua.Model.Collections;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
    public class VitalSignsViewModel:ViewModelBase
    {
        public VitalSignsViewModel(MainWindowViewModel owner)
        {
            this.mainWindowViewModel = owner;
            this.mainWindowViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(mainWindowViewModel_PropertyChanged);
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VitalSignsViewModel_PropertyChanged);
        }

        #region Fields
        private MainWindowViewModel mainWindowViewModel;
        private VitalsCollection bPVitals;
        private VitalsCollection temperatureVitals;
        private VitalsCollection pulseVitals;
        private VitalsCollection respiratoryRateVitals;
        private VitalsCollection painVitals;
        private WorkspaceItemState workSpaceItemState;
        #endregion
        
        #region Properties
        
        public WorkspaceItemState WorkSpaceItemState
        {
            get { return this.workSpaceItemState; }
            set
            {
                this.workSpaceItemState = value;
                OnPropertyChanged("WorkSpaceItemState");
            }
        }
        
        public VitalsCollection BPVitals
        {
            get
            {
                if(this.Vitals !=null)
                {
                    GetBPVitals(this.Vitals);
                    
                    return this.bPVitals;
                }
                
                return new VitalsCollection();
            }
        }
        
        public VitalsCollection TemperatureVitals
        {
            get
            {
                if (this.Vitals != null)
                {
                    GetTemperatureVitals(this.Vitals);
                    return this.temperatureVitals;
                }
                return new VitalsCollection();
            }
        }
        
        public VitalsCollection PulseVitals
        {
            get
            {
                if (this.Vitals != null)
                {
                    GetPulseVitals(this.Vitals);
                    return this.pulseVitals;
                }
                return new VitalsCollection();
            }
        }
        
        public VitalsCollection RespiratoryRateVitals
        {
            get
            {
                if (this.Vitals != null)
                {
                    GetRespiratoryRateVitals(this.Vitals);
                    return this.respiratoryRateVitals;
                }
                return new VitalsCollection();
            }
        }
        
        public VitalsCollection PainVitals
        {
            get
            {
                if (this.Vitals != null)
                {
                    GetPainVitals(this.Vitals);
                    return this.painVitals;
                }
                return new VitalsCollection();
            }
        }
        
        public VitalsCollection Vitals
        {
            get
            {
                if (this.mainWindowViewModel.SelectedPatient != null)
                {
                    VitalsCollection result = null;
                    if (this.mainWindowViewModel.SelectedPatient.Vitals != null)
                    {
                        result = this.mainWindowViewModel.SelectedPatient.Vitals;
                    }
                    else
                    {
                        result = new VitalsCollection();
                    }
                    return result;
                }
                return null;
                
            }
        }
        
        public DataView EKGData
        {
            get { return GetEKGData().DefaultView; }
        }
        
        public Visibility NormalStateVisibility
        {
            get
            {
                if (this.WorkSpaceItemState != WorkspaceItemState.Maximized && this.bPVitals != null)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }
        
        public Visibility MaximizedStateVisiblity
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
        #endregion
        
        #region Event Handlers
        void VitalSignsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "WorkSpaceItemState")
            {
                this.OnPropertyChanged("NormalStateVisibility");
                this.OnPropertyChanged("MaximizedStateVisiblity");
            }
        }

        void mainWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedPatient")
            {
                this.OnPropertyChanged("Vitals");
                this.OnPropertyChanged("EKGData");
                this.OnPropertyChanged("BPVitals");
                this.OnPropertyChanged("NormalStateVisibility");
                this.OnPropertyChanged("TemperatureVitals");
                this.OnPropertyChanged("PulseVitals");
                this.OnPropertyChanged("RespiratoryRateVitals");
                this.OnPropertyChanged("PainVitals");

            }
        }

        #endregion
        
        #region Private Methods
        private void GetBPVitals(VitalsCollection Vitals)
        {
            var BPVitals = (from vital in Vitals where vital.VitalSignType.Name == "Blood Pressure" select vital);
            this.bPVitals = new VitalsCollection(BPVitals);
        }

        private void GetTemperatureVitals(VitalsCollection Vitals)
        {
            var TemperatureVitals = (from vital in Vitals where vital.VitalSignType.Name == "Temperature" select vital);
            this.temperatureVitals = new VitalsCollection(TemperatureVitals);
        }

        private void GetPulseVitals(VitalsCollection Vitals)
        {
            var PulseVitals = (from vital in Vitals where vital.VitalSignType.Name == "Pulse" select vital);
            this.pulseVitals = new VitalsCollection(PulseVitals);
        }

        private void GetRespiratoryRateVitals(VitalsCollection Vitals)
        {
            var RespiratoryRateVitals = (from vital in Vitals where vital.VitalSignType.Name == "Respiratory Rate" select vital);
            this.respiratoryRateVitals = new VitalsCollection(RespiratoryRateVitals);
        }

        private void GetPainVitals(VitalsCollection Vitals)
        {
            var PainVitals = (from vital in Vitals where vital.VitalSignType.Name == "Pain" select vital);
            this.painVitals = new VitalsCollection(PainVitals);
        }
        
        private DataTable GetEKGData()
        {
            DataTable dt = new DataTable();
            object[] ecgValues = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 5.25, 4.5, 3.75, 3, 2.25, 1.5, .75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -2.33, -4.66, -7, 8, 23, 38, 53, 36, 19, 2, -15, -12, -9, -6, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .95, 1.9, 2.85, 3.8, 4.75, 5.7, 6.65, 7.6, 8.55, 9.5, 8.31, 7.11, 5.91, 4.71, 3.51, 2.31, 1.11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            dt.Columns.Add("EKGValues", typeof(double));
            for (int i = 0; i < ecgValues.Length; i++)
                dt.Rows.Add(ecgValues[i]);
            return dt;
        }

        #endregion

    }
}
