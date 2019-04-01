using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infragistics.Guidance.Aqua.Model.Framework
{
	public static class DateTimeExtension
    {
        #region Methods
        public static DateTime ConvertToDateTime(this String value)
		{
			DateTime result = DateTime.MinValue;

			DateTime.TryParse(value, out result);
			if (result == null)
			{
				result = DateTime.MinValue;
			}
			
			return result;
		}

		public static DateTime ConvertToDateTime(this DateTime? value)
		{
			DateTime result = DateTime.MinValue;

			if (value != null)
			{
				result = (DateTime)value;	
			}
			
			return result;
        }
        #endregion
    }
}
