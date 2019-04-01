using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Windows.TilePanel;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Model.Collections;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
    public class ClinicalNotesViewModel:ViewModelBase
    {
        public ClinicalNotesViewModel(MainWindowViewModel owner)
        {
            mainWindowViewModel = owner;
            mainWindowViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(mainWindowViewModel_PropertyChanged);
        }
        #region Fields
        private MainWindowViewModel mainWindowViewModel;
        private WorkspaceItemState workSpaceItemState;
        #endregion
        #region Properties
        public ClinicalNotesCollection ClinicalNotes
        {
            get
            {
                if (mainWindowViewModel.SelectedPatient != null)
                {
                    return mainWindowViewModel.SelectedPatient.ClinicalNotes;
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
        #endregion
        #region Event Handlers
        void mainWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedPatient")
            {
                this.OnPropertyChanged("ClinicalNotes");
            }
        }
#endregion

    }
}
