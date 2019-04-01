using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Infragistics.Windows.TilePanel;
using Infragistics.Guidance.Aqua.Model.Collections;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        public OrdersViewModel(MainWindowViewModel owner)
        {
            this.mainWindowViewModel = owner;
            this.mainWindowViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(mainWindowViewModel_PropertyChanged);
        }


        #region Fields
        private MainWindowViewModel mainWindowViewModel;
        private WorkspaceItemState workSpaceItemState; 
        #endregion
        #region Properties
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


        public WorkspaceItemState WorkSpaceItemState
        {
            get { return this.workSpaceItemState; }
            set
            {
                this.workSpaceItemState = value;
                OnPropertyChanged("WorkSpaceItemState");
            }
        }
        public MedicationsCollection AllMedications
        {
            get { return this.mainWindowViewModel.AllMedications; }
        }
        #endregion
        #region Event Handlers
        void mainWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedPatient")
            {
                this.OnPropertyChanged("MedicationOrders");
            }
            if (e.PropertyName == "AllMedications")
            {
                this.OnPropertyChanged("AllMedications");
                if (this.MedicationOrders != null)
                {
                    this.OnPropertyChanged("MedicationOrders");
                }
                
            }
        }
        #endregion
        

        
    }
}
