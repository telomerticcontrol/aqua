using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Infragistics.Windows.Chart;
using Infragistics.Guidance.Aqua.Client.ViewModel;
using Infragistics.Silverlight.Timeline;

namespace Infragistics.Guidance.Aqua.Client.View
{
    /// <summary>
    /// Interaction logic for VitalSignsView.xaml
    /// </summary>
    public partial class VitalSignsView : UserControl
    {
        public VitalSignsView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(VitalSignsView_Loaded);
            this.BPChartNormal.Loaded += new RoutedEventHandler(BPChartNormal_Loaded);
        }
        
        #region Fields
        private VitalSignsViewModel vitalSignsViewModel;
        #endregion

        #region Event Handlers
        void BPChartNormal_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.vitalSignsViewModel.BPVitals.Count == 0)
            {

                DataPoint dp = new DataPoint();
                ChartParameter cpHigh = new ChartParameter();
                cpHigh.Type = ChartParameterType.High;
                cpHigh.Value = 50;
                dp.ChartParameters.Add(cpHigh);
                ChartParameter cpLow = new ChartParameter();
                cpLow.Type = ChartParameterType.Low;
                cpLow.Value = 0;
                dp.ChartParameters.Add(cpLow);
                ChartParameter cpOpen = new ChartParameter();
                cpOpen.Type = ChartParameterType.Open;
                cpOpen.Value = 0;
                dp.ChartParameters.Add(cpOpen);
                ChartParameter cpClose = new ChartParameter();
                cpClose.Type = ChartParameterType.Close;
                cpClose.Value = 0;
                dp.ChartParameters.Add(cpClose);

                BPChartNormal.Series[0].DataPoints.Clear();
                BPChartMaximized.Series[0].DataPoints.Clear();
                BPChartNormal.Series[0].DataPoints.Add(dp);
                BPChartMaximized.Series[0].DataPoints.Add(dp);
            }
        }

        void VitalSignsView_Loaded(object sender, RoutedEventArgs e)
        {
            this.vitalSignsViewModel = this.DataContext as VitalSignsViewModel;
            this.vitalSignsViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_VitalSignsViewModel_PropertyChanged);

        }

        void _VitalSignsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "BPVitals")
            {
                for (int datapoint = 0; datapoint < this.BPChartNormal.Series[0].DataPoints.Count; datapoint++)
                {
                    this.BPChartNormal.Series[0].DataPoints[datapoint].ToolTip = String.Format("{0}/{1}", this.BPChartNormal.Series[0].DataPoints[datapoint].ChartParameters[0].Value.ToString(), this.BPChartNormal.Series[0].DataPoints[datapoint].ChartParameters[1].Value.ToString());
                }
                for (int datapoint = 0; datapoint < this.BPChartMaximized.Series[0].DataPoints.Count; datapoint++)
                {
                    this.BPChartMaximized.Series[0].DataPoints[datapoint].ToolTip = String.Format("{0}/{1}", this.BPChartMaximized.Series[0].DataPoints[datapoint].ChartParameters[0].Value.ToString(), this.BPChartMaximized.Series[0].DataPoints[datapoint].ChartParameters[1].Value.ToString());
                }
            }

        }



        private void BPNormalSeriesLoaded(object sender, RoutedEventArgs e)
        {
            for (int datapoint = 0; datapoint < this.BPChartNormal.Series[0].DataPoints.Count; datapoint++)
            {
                this.BPChartNormal.Series[0].DataPoints[datapoint].ToolTip = String.Format("{0}/{1}", this.BPChartNormal.Series[0].DataPoints[datapoint].ChartParameters[0].Value.ToString(), this.BPChartNormal.Series[0].DataPoints[datapoint].ChartParameters[1].Value.ToString());
            }
        }

        private void BPMaximizedSeriesLoaded(object sender, RoutedEventArgs e)
        {
            for (int datapoint = 0; datapoint < this.BPChartMaximized.Series[0].DataPoints.Count; datapoint++)
            {
                this.BPChartMaximized.Series[0].DataPoints[datapoint].ToolTip = String.Format("{0}/{1}", this.BPChartMaximized.Series[0].DataPoints[datapoint].ChartParameters[0].Value.ToString(), this.BPChartMaximized.Series[0].DataPoints[datapoint].ChartParameters[1].Value.ToString());
            }
        }
        #endregion

        




    }
}
