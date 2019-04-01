using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Model.Collections;
using Infragistics.Guidance.Aqua.Client.Collections;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
    public class PatientRecordItemsViewModel: ViewModelBase
    {
        public PatientRecordItemsViewModel(Admittance amdittance, PatientRecordViewModel parent)
        {
            this.admittance = amdittance;
            this.parent = parent;

        }
        
        #region Fields
        private Admittance admittance;
        private PatientRecordViewModel parent;
        private TestResultViewModelCollection imageTests;
        #endregion

        #region Properties
        public PatientRecordItemsViewModel ThisPatientRecordItem
        {
            get { return this; }
        }
        public PatientRecordViewModel Parent
        {
            get { return this.parent; }
        }
        public Admittance Admittance
        {
            get { return this.admittance; }
        }

        public DateTime AdmittanceDate
        {
            get { return this.Admittance.TimestampIn; }
        }

        public string Diagnosis
        {
            get 
            {
                if (string.IsNullOrEmpty(this.Admittance.Diagnosis))
                {
                    return "No Diagnosis";
                }
                return this.Admittance.Diagnosis; }
        }

        public TestResultViewModelCollection ImageTests
        {
            get
            {
                GetImageTests(Admittance.Tests);
                return this.imageTests;
            }
        }
        public ClinicalNotesCollection ClinicalNotes
        {
            get { return this.Admittance.ClinicalNotes; }
        }


        public void SetUpBodyRegions()
        {
            foreach (TestResultViewModel test in ImageTests)
            {
                switch (test.BodyRegion.Name)
                {
                    case "RightArm":
                        {
                            this.Parent.HasRightArmImages = true;
                            break;
                        }
                    case "LeftArm":
                        {
                            this.Parent.HasLeftArmImages = true;
                            break;
                        }
                    case "RightLeg":
                        {
                            this.Parent.HasRightLegImages = true;
                            break;
                        }
                    case "LeftLeg":
                        {
                            this.Parent.HasLeftLegImages = true;
                            break;
                        }
                    case "Torso":
                        {
                            this.Parent.HasTorsoImages = true;
                            break;
                        }
                    case "Head":
                        {
                            this.Parent.HasHeadImages = true;
                            break;
                        }
                }
            }
        }
        #endregion

        #region Methods
        private void GetImageTests(TestCollection Tests)
        {
            var ImgTests = from test in Tests where test.TestType.ResultType == "image" select test;
            this.imageTests = new TestResultViewModelCollection();
            foreach (Test test in ImgTests)
            {
                this.imageTests.Add(new TestResultViewModel(this.Admittance, test));
            }

        }
        #endregion
        
        
    }
}
