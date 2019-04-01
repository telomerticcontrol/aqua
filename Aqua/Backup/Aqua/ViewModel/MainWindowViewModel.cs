using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Model.Collections;
using Infragistics.Guidance.Aqua.Client.Collections;
using Microsoft.LiveFX.Client;
using Infragistics.Guidance.Aqua.DataClient.Commands;
using Infragistics.Guidance.Aqua.Model.Framework;
using System.Configuration;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
	public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(Dispatcher dispatcher)
        {
            this.mainWindowDisptacher = dispatcher;
        }

       
        public void Initialize()
        {
            if (ConfigurationManager.AppSettings["ShowLogin"].ToString() == "false")
            {
                this.NeedsAuthentication = false;
                GetPatientData();
            }
            else
            {
                this.NeedsAuthentication = true;
                GetPatientData();
            }
        }
        
        #region Fields
        private Dispatcher mainWindowDisptacher;
        private PatientViewModel selectedPatient;
        private AdmittanceCollection hospitalAdmittants;
        private PatientViewModelCollection patientList;
        private MedicationsCollection allMedications = null;
        private string loginName = string.Empty;
        private LiveOperatingEnvironment liveOperatingEnvironment;
        private string liveAuthenticationToken;
        
        private bool needsAuthentication;
        private DiagnosisLibraryItemCollection libraryItems;

        #endregion
        #region Events
        public event EventHandler LoginRequested;
        public event EventHandler LoginComplete;

        public event EventHandler SelectedPatientChanging;
        public event EventHandler SelectedPatientCompleted;
        #endregion
        #region Properties
        public PatientViewModel SelectedPatient
        {
            get { return this.selectedPatient; }
            set
            {
                if (this.selectedPatient != value)
                {
                    this.selectedPatient = value;
                    this.ExecuteChangePatientCommand();
                }
            }
        }
        public MedicationsCollection AllMedications
        {
            get
            {
                return this.allMedications;
            }
        }

        public DiagnosisLibraryItemCollection LibraryItems
        {
            get { return this.libraryItems; }
        }

        public string LiveAuthenticationToken
        {
            get { return this.liveAuthenticationToken; }
            set
            {
                this.liveAuthenticationToken = value;
                OnPropertyChanged("LiveAuthenticationToken");
            }
        }

        public LiveOperatingEnvironment LiveOperatingEnvironment
        {
            get { return this.liveOperatingEnvironment; }
            set
            {
                this.liveOperatingEnvironment = value;
                OnPropertyChanged("LiveOperatingEnvironment");
            }
        }

        public string LoginName
        {
            get
            {
                string[] loginNameArray = this.loginName.Split(' ');
                if (loginNameArray.Length > 1)
                {
                    return "Dr. " + loginNameArray[1];
                }
                else
                {
                    return this.loginName;
                }

            }
            set
            {
                this.loginName = value;
                OnPropertyChanged("LoginName");
            }
        }

        public bool NeedsAuthentication
        {
            get { return this.needsAuthentication; }
            set
            {
                this.needsAuthentication = value;
                OnPropertyChanged("NeedsAuthentication");
                if (NeedsAuthentication)
                {
                    if (this.LoginRequested != null)
                    {
                        this.LoginRequested(this, EventArgs.Empty);
                    }
                }
                else
                {
                    if (this.LoginComplete != null)
                    {
                        this.LoginComplete(this, EventArgs.Empty);
                    }

                }
            }
        }

        public AdmittanceCollection HospitalAdmittants
        {
            get { return this.hospitalAdmittants; }
        }
        public PatientViewModelCollection PatientList
        {
            get { return this.patientList; }
        }

        public EDPatientsListViewModel EDPatientsList
        {
            get { return new EDPatientsListViewModel(this); }
        }
        public OrdersViewModel OrdersViewModel
        {
            get { return new OrdersViewModel(this); }
        }
        public ClinicalNotesViewModel ClinicalNotesViewModel
        {
            get { return new ClinicalNotesViewModel(this); }
        }

        public VitalSignsViewModel VitalSignsViewModel
        {
            get { return new VitalSignsViewModel(this); }
        }

        public PatientRecordViewModel PatientRecordViewModel
        {
            get { return new PatientRecordViewModel(this); }
        }

        public DiagnosisSupportViewModel DiagnosisSupportViewModel
        {

            get { return new DiagnosisSupportViewModel(this); }
        }

        public TestResultsViewModel TestResultsViewModel
        {
            get { return new TestResultsViewModel(this); }
        }
        #endregion		
        #region Event Handlers
        private void LibraryCommand_Complete(DiagnosisLibraryItemCollection libraryItems)
        {
            this.libraryItems = libraryItems;
            this.OnPropertyChanged("LibraryItems");
        }
        private void MedicationCommand_Complete(MedicationsCollection medications)
        {
            this.allMedications = medications;
            this.OnPropertyChanged("AllMedications");
        }


        private void AdmittanceCommand_Complete(AdmittanceCollection hospitalAdmittants)
        {
            this.hospitalAdmittants = hospitalAdmittants;

            this.patientList = new PatientViewModelCollection();
            foreach (Admittance a in this.hospitalAdmittants)
            {
                PatientViewModel pvm = new PatientViewModel(a);
                this.patientList.Add(pvm);
            }


            if (this.patientList.Count > 0)
            {
                this.SelectedPatient = this.patientList[0];
            }
            this.OnPropertyChanged("EDPatientsList");
            this.OnPropertyChanged("HospitalAdmittants");
            this.OnPropertyChanged("PatientList");
           


        }
        private void LoginCommand_Complete(LiveStatus liveStatus)
        {

            if (liveStatus.HasLoginErrors)
            {
                MessageBox.Show(liveStatus.LoginErrorMessage, "Live Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                this.liveAuthenticationToken = liveStatus.Token;
                this.liveOperatingEnvironment = liveStatus.LiveOperatingEnvironment;
                this.loginName = this.liveOperatingEnvironment.Mesh.ProvisionedUser.Name;
                OnPropertyChanged("LiveOperatingEnvironment");
                OnPropertyChanged("LoginName");
                this.NeedsAuthentication = false;
                OnPropertyChanged("NeedsAuthentication");

            }
        }
        #endregion
        #region Methods
        private void GetPatientData()
        {
            GetMedicationsCommand medCommand = new GetMedicationsCommand();
            medCommand.Execute(MedicationCommand_Complete, CommandCriteria.EmptyCommand);

            GetAdmittanceCommand command = new GetAdmittanceCommand();
            command.Execute(AdmittanceCommand_Complete, CommandCriteria.EmptyCommand);

            GetLibraryItemsCommand libCommand = new GetLibraryItemsCommand();
            libCommand.Execute(LibraryCommand_Complete, CommandCriteria.EmptyCommand);

        }

        public void LoginToLive(string userName, string password)
        {
            CommandCriteria criteria = new CommandCriteria();
            criteria.Add("UserName", userName);
            criteria.Add("Password", password);

            GetLiveLoginInfoCommand loginCommand = new GetLiveLoginInfoCommand();
            loginCommand.Execute(LoginCommand_Complete, criteria);

        }
        #endregion
		#region Async Command Processing

		/// <summary>
		/// Execute the command for retrieving data for the currently selected patient/admittance.
		/// </summary>
		/// <remarks>This method checks to see if the admittance was already previously loaded</remarks>
		private void ExecuteChangePatientCommand()
		{
			if (!this.selectedPatient.Admittance.IsDataLoaded)
			{
				// Raise Story Board Event
				if (this.SelectedPatientChanging != null)
				{
					this.SelectedPatientChanging(this, EventArgs.Empty);
				}

				CommandCriteria criteria = new CommandCriteria();
				criteria.Add("Admittance", this.selectedPatient.Admittance);

				ChangePatientCommand command = new ChangePatientCommand();
				command.Execute(PatientChanged, criteria);
			}
			else // If data is already loaded make sure to send data binding notification
			{
				this.NotifyPatientChanged();
			}
		}
		
		/// <summary>
		/// Callback method that executes when the change patient command is complete
		/// </summary>
		/// <param name="patient">Selected Patient</param>
		/// <remarks>This forces the property notification to occur on the UI Thread</remarks>
		private void PatientChanged(Patient patient)
		{

			if (this.SelectedPatientCompleted != null)
			{
				this.SelectedPatientCompleted(this, EventArgs.Empty);
			}

			// Force the property notificat
			this.mainWindowDisptacher.Invoke(DispatcherPriority.Normal,
				new Action(NotifyPatientChanged));
		}

		/// <summary>
		/// Notify the related view models/views about the patient being changed.
		/// </summary>
		private void NotifyPatientChanged()
		{
			this.OnPropertyChanged("SelectedPatient");
		}

		#endregion
		
		
	}
}
