using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Infragistics.Guidance.Aqua.Model;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Model.Collections;

namespace Infragistics.Guidance.Aqua.Client.Converters
{
    class TestResultsToFieldsConverter: IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TestCollection tests = value as TestCollection;
            DateTime dt = DateTime.Parse(parameter.ToString());
            System.Diagnostics.Debug.WriteLine(dt.ToLongTimeString() +"  " +dt.ToShortDateString());
            for (int i = 0; i < tests.Count; i++ )
            {
                if (tests[i].Timestamp == dt)
                {
                    return tests[i].Result;
                   
                }
               
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
