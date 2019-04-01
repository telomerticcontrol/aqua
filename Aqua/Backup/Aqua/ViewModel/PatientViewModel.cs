using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Infragistics.Guidance.Aqua.Model.Collections;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
	public class PatientViewModel : ViewModelBase
    {
        public PatientViewModel(Admittance admittance)
        {
            this.admittance = admittance;
            this.admittance.PropertyChanged += new PropertyChangedEventHandler(Admittance_PropertyChanged);
            this.booleanToVisibilityConverter = new BooleanToVisibilityConverter();
        }

        #region Fields
        private Admittance admittance;
        private Random randomProcessingState;
        private BooleanToVisibilityConverter booleanToVisibilityConverter;
        #endregion

        #region Properties
        public AdmittanceCollection Admittances
        {
            get { return this.EDPatient.Admittances; }
        }

        public string Complaints
        {
            get
            {
                string result = string.Empty;

                if (this.Admittance.Complaints != null)
                {
                    result = this.Admittance.Complaints.PatientComplaint;
                }

                return result;
            }
        }
        public string Severity
        {
            get { return this.Admittance.Severity; }
        }
        public Patient EDPatient
        {
            get { return this.Admittance.EDPatient; }
        }

        public string DOBString
        {
            get
            {
                return this.EDPatient.DOB.ToShortDateString();
            }
        }
        public string AdmittanceDate
        {
            get { return this.Admittance.TimestampIn.ToShortDateString(); }
        }

        public string PatientFullName
        {
            get { return string.Format("{0}, {1}", this.EDPatient.LastName, this.EDPatient.FirstName); }
        }

        public ClinicalNotesCollection ClinicalNotes
        {
            get { return this.Admittance.ClinicalNotes; }
        }

        public HospitalStaffCollection HospitalStaff
        {
            get { return this.Admittance.HospitalStaff; }
        }

        public Admittance Admittance
        {
            get { return this.admittance; }
        }

        public VitalsCollection Vitals
        {
            get { return this.Admittance.Vitals; }
        }

        public TestCollection Tests
        {
            get { return this.Admittance.Tests; }
        }
        public MedicationOrdersCollection Orders
        {
            get { return this.Admittance.Orders; }
        }

        public AllergyCollection Allergies
        {
            get { return this.EDPatient.Allergies; }
        }
        public string AllergyList
        {
            get
            {
                string allergyList = string.Empty;

                if (this.Allergies != null)
                {
                    for (int i = 0; i < this.Allergies.Count; i++)
                    {
                        allergyList += this.Allergies[i].Allergy.Name + ", ";
                    }
                    if (allergyList.EndsWith(", "))
                    {
                        allergyList = allergyList.Remove(allergyList.Length - 2, 2);
                    }
                }

                return allergyList;
            }
        }

        public Visibility DNRVisibility
        {
            get { return (Visibility)this.booleanToVisibilityConverter.Convert(this.EDPatient.DNR, null, null, null); }
        }
        public Visibility VIPVisibility
        {
            get { return (Visibility)this.booleanToVisibilityConverter.Convert(this.EDPatient.VIP, null, null, null); }
        }
        public Visibility InfectiousVisibility
        {
            get { return (Visibility)this.booleanToVisibilityConverter.Convert(this.EDPatient.Infectious, null, null, null); }
        }
        public string AttendingName
        {
            get { return this.Admittance.Attending.Suffix + this.Admittance.Attending.LastName; }
        }
        public string RNName
        {
            get { return this.Admittance.Nurse.FirstName + " " + this.Admittance.Nurse.LastName; }
        }
        public string Disposition
        {
            get { return this.Admittance.Disposition; }
        }
        public string Comments
        {
            get { return this.Admittance.Comments; }
        }
        public string Location
        {
            get { return this.Admittance.Location; }
        }

        public OrderProcessingState VitalsOrderState
        {
            get
            {
                randomProcessingState = new Random();
                return (OrderProcessingState)randomProcessingState.Next(0, 5);
            }

        }

        public OrderProcessingState EKGOrderState
        {
            get
            {
                randomProcessingState = new Random();
                return (OrderProcessingState)randomProcessingState.Next(0, 5);
            }

        }

        public OrderProcessingState LabOrderState
        {
            get
            {
                randomProcessingState = new Random();
                return (OrderProcessingState)randomProcessingState.Next(0, 5);
            }


        }
        #endregion

        #region Event Handlers
        void Admittance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Complaints")
            {
                this.OnPropertyChanged("Complaints");
            }
        }
        #endregion
       
	}
}
