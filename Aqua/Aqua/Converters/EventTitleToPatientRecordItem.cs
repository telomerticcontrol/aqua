using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Infragistics.Guidance.Aqua.Client.ViewModel;

namespace Infragistics.Guidance.Aqua.Client.Converters
{
    class EventTitleToPatientRecordItem: IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            PatientRecordItemsViewModel privm = value as PatientRecordItemsViewModel;
            if (privm != null)
            {
                switch (parameter.ToString())
                {
                    case "Date":
                        {
                            return privm.AdmittanceDate.ToShortDateString();
                            break;
                        }
                    case "Diagnosis":
                        {
                            return privm.Diagnosis;
                            break;
                        }
                    case "Notes":
                        {
                            return privm.ClinicalNotes;
                            break;
                        }
                }
            }
            
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
