using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
    public class TestResultViewModel: ViewModelBase
    {

        public TestResultViewModel(Admittance admittance, Test test)
        {
            this.admittance = admittance;           
            this.test = test;
        }

        #region Fields
        private Test test = null;
        private Admittance admittance = null;
        #endregion
        #region Properties
        public Admittance Admittance
        {
            get { return this.admittance; }
        }
        public Test Test
        {
            get { return this.test; }
        }
        public string Type
        {
            get { return this.Test.TestType.Name; }
        }
        public string Category
        {
            get { return this.Test.TestType.TestCategory.Name; }
        }
        public string Image
        {
            get
            {
                if (this.Test.TestType.Name != "Lab")
                {
                    return @"\Images\" + this.Test.Result;
                }
                return string.Empty;
            }

        }
        public string Timestamp
        {
            get { return this.Test.Timestamp.ToShortDateString(); }

        }

        public BodyRegion BodyRegion
        {
            get { return this.Test.BodyRegion; }
        }

        #endregion
    
    }
}
