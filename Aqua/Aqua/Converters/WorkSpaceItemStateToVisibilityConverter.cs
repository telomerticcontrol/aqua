using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using Infragistics.Windows.TilePanel;

namespace Infragistics.Guidance.Aqua.Client.Converters
{
    class WorkSpaceItemStateToVisibilityConverter: IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            WorkspaceItemState state = (WorkspaceItemState)value;
            if (state != null)
            {
                switch (state)
                {
                    case WorkspaceItemState.Normal:
                        {
                            return Visibility.Collapsed;
                            break;
                        }
                    case WorkspaceItemState.Maximized:
                        {
                            return Visibility.Visible;
                            break;
                        }
                    case WorkspaceItemState.MinimizedCollapsed:
                        {
                            return Visibility.Collapsed;
                            break;
                        }
                    case WorkspaceItemState.MinimizedExpanded:
                        {
                            return Visibility.Collapsed;
                            break;
                        }
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
