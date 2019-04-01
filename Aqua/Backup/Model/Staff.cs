using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.Model
{
	public class Staff : BaseModel
    {
        #region Properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string Speciality { get; set; }
        public int StaffTypeID { get; set; }
        public StaffType StaffType { get; set; }
        #endregion
    }
}
