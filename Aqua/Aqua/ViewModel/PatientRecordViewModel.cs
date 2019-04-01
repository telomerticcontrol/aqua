using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Windows.TilePanel;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Client.Collections;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
    public class PatientRecordViewModel:ViewModelBase
    {
        public PatientRecordViewModel(MainWindowViewModel owner)
        {
            this.mainWindowViewModel = owner;
            this.mainWindowViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(mainWindowViewModel_PropertyChanged);

        }
        
        #region Fields
        private MainWindowViewModel mainWindowViewModel;
        private PatientRecordItemsViewModel selectedRecord;
        private PatientRecordItemsViewModelCollection admittanceRecord;
        private WorkspaceItemState _WorkSpaceItemState;
        private Boolean hasRightArmImages = false;
        private Boolean hasLeftArmImages = false;
        private Boolean hasRightLegImages = false;
        private Boolean hasLeftLegImages = false;
        private Boolean hasTorsoImages = false;
        private Boolean hasHeadImages = false;
        #endregion

        #region Properties
        public WorkspaceItemState WorkSpaceItemState
        {
            get { return _WorkSpaceItemState; }
            set
            {
                this._WorkSpaceItemState = value;
                OnPropertyChanged("WorkSpaceItemState");
            }
        }

        public PatientRecordItemsViewModelCollection AdmittanceRecord
        {
            get
            {
                if (this.mainWindowViewModel.SelectedPatient != null)
                {
                    this.admittanceRecord = new PatientRecordItemsViewModelCollection();
                    foreach (Admittance a in this.mainWindowViewModel.SelectedPatient.Admittances)
                    {
                        this.admittanceRecord.Add(new PatientRecordItemsViewModel(a, this));
                    }
                    return this.admittanceRecord;
                }
                return null;
            }
        }


        public PatientRecordItemsViewModel SelectedRecord
        {
            get
            {
                return this.selectedRecord;
            }
            set
            {
                this.selectedRecord = value;
                this.OnPropertyChanged("SelectedRecord");
            }
        }

        public Boolean HasRightArmImages
        {
            get { return this.hasRightArmImages; }
            set
            {
                this.hasRightArmImages = value;
                OnPropertyChanged("HasRightArmImages");
            }
        }
        public Boolean HasLeftArmImages
        {
            get { return this.hasLeftArmImages; }
            set
            {
                this.hasLeftArmImages = value;
                OnPropertyChanged("HasLeftArmImages");
            }
        }
        public Boolean HasRightLegImages
        {
            get { return this.hasRightLegImages; }
            set
            {
                this.hasRightLegImages = value;
                OnPropertyChanged("HasRightLegImages");
            }
        }
        public Boolean HasLeftLegImages
        {
            get { return this.hasLeftLegImages; }
            set
            {
                this.hasLeftLegImages = value;
                OnPropertyChanged("HasLeftLegImages");
            }
        }
        public Boolean HasTorsoImages
        {
            get { return this.hasTorsoImages; }
            set
            {
                this.hasTorsoImages = value;
                OnPropertyChanged("HasTorsoImages");
            }
        }
        public Boolean HasHeadImages
        {
            get { return this.hasHeadImages; }
            set
            {
                this.hasHeadImages = value;
                OnPropertyChanged("HasHeadImages");
            }
        }
        #endregion

        #region Event Handlers
        void mainWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedPatient")
            {
                this.OnPropertyChanged("AdmittanceRecord");
            }
        }
        #endregion


    }
}
