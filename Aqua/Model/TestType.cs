using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.Model
{
	public class TestType : BaseModel
    {
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string ResultType { get; set; }
        public int TestCategoryID { get; set; }
        public TestCategory TestCategory { get; set; }
		public bool CompareTestCategory(string name)
		{
			return this.TestCategory != null
				&& this.TestCategory.Name == name;
        }
        #endregion
    }
}
