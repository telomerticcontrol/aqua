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
using Infragistics.Guidance.Aqua.Client.ViewModel;
using Infragistics.Guidance.Aqua.Client.Converters;
using Infragistics.Windows.DataPresenter;
using System.ComponentModel;
using Infragistics.Windows.TilePanel;
using Infragistics.Windows.Controls;
using Infragistics.Guidance.Aqua.Client.Common;

namespace Infragistics.Guidance.Aqua.Client.View
{
    /// <summary>
    /// Interaction logic for EDPatientsListView.xaml
    /// </summary>
    public partial class EDPatientsListView : UserControl
    {
        EDPatientsListViewModel edPatientsListViewModel;
        public EDPatientsListView()
        {
            InitializeComponent();
            xdgEDPatientsListNormal.RecordsInViewChanged += new EventHandler<Infragistics.Windows.DataPresenter.Events.RecordsInViewChangedEventArgs>(xdgEDPatientsListNormal_RecordsInViewChanged);
            xdgEDPatientsListMaximized.RecordsInViewChanged += new EventHandler<Infragistics.Windows.DataPresenter.Events.RecordsInViewChangedEventArgs>(xdgEDPatientsListMaximized_RecordsInViewChanged);
            xdgVitalsMaximized.InitializeRecord += new EventHandler<Infragistics.Windows.DataPresenter.Events.InitializeRecordEventArgs>(xdgVitalsMaximized_InitializeRecord);
            this.Loaded += new RoutedEventHandler(EDPatientsListView_Loaded);
        }

        void xdgEDPatientsListMaximized_RecordsInViewChanged(object sender, Infragistics.Windows.DataPresenter.Events.RecordsInViewChangedEventArgs e)
        {
            if (this.xdgEDPatientsListMaximized.ActiveRecord == null)
            {
                this.xdgEDPatientsListMaximized.ActiveRecord = this.xdgEDPatientsListMaximized.GetRecordsInView(false)[0];
            }
        }

        void xdgEDPatientsListNormal_RecordsInViewChanged(object sender, Infragistics.Windows.DataPresenter.Events.RecordsInViewChangedEventArgs e)
        {
            if (this.xdgEDPatientsListNormal.ActiveRecord == null)
                this.xdgEDPatientsListNormal.ActiveRecord = this.xdgEDPatientsListNormal.GetRecordsInView(false)[0];
        }

        void EDPatientsListView_Loaded(object sender, RoutedEventArgs e)
        {
            edPatientsListViewModel = this.DataContext as EDPatientsListViewModel;
            if (edPatientsListViewModel != null)
            {
                edPatientsListViewModel.PropertyChanged += new PropertyChangedEventHandler(edPatientsListViewModel_PropertyChanged);
            }
        }

        void edPatientsListViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "WorkSpaceItemState")
            {
                if (edPatientsListViewModel.WorkSpaceItemState == WorkspaceItemState.Maximized)
                {
                    edPatientsListViewModel.StartEKGTimer();
                }
                else
                {
                    edPatientsListViewModel.StopEKGTimer();
                }
            }
        }

        void xdgVitalsMaximized_InitializeRecord(object sender, Infragistics.Windows.DataPresenter.Events.InitializeRecordEventArgs e)
        {
           
	
           if (e.Record.GetType() != typeof(GroupByRecord))
           {
               DataRecord dr = e.Record as DataRecord;
               switch (dr.Cells["Type"].Value.ToString())
               {
                   case "Temperature":
                       {
                           dr.Cells["AverageValue"].Value = "(98.6)";
                           break;
                       }
                   case "Blood Pressure":
                       {
                           dr.Cells["AverageValue"].Value = "(<90/<60)";
                           break;
                       }

                   case "Respiratory Rate":
                       {
                           dr.Cells["AverageValue"].Value = "(12-20)";
                           break;
                       }
               }
           }
           else
           {
               GroupByRecord gbr = e.Record as GroupByRecord;
               if (gbr.Index == 0)
               {
                   gbr.IsExpanded = true;
               }
           }
        }
        
        private void xdgEDPatientsListNormal_Sorted(object sender, Infragistics.Windows.DataPresenter.Events.SortedEventArgs e)
        {
            FieldSortDescription sortDescription = new FieldSortDescription()
            {
                FieldName = e.SortDescription.FieldName,
                IsGroupBy = false,
                Direction = e.SortDescription.Direction
            };
            
            this.xdgEDPatientsListMaximized.FieldLayouts[0].SortedFields.Clear();
            this.xdgEDPatientsListMaximized.FieldLayouts[0].SortedFields.Add(sortDescription);  
        }

        private void xdgEDPatientsListMaximized_Sorted(object sender, Infragistics.Windows.DataPresenter.Events.SortedEventArgs e)
        {
            FieldSortDescription sortDescription = new FieldSortDescription()
            {
                FieldName = e.SortDescription.FieldName,
                IsGroupBy = false,
                Direction = e.SortDescription.Direction
            };
            this.xdgEDPatientsListNormal.FieldLayouts[0].SortedFields.Clear();
            this.xdgEDPatientsListNormal.FieldLayouts[0].SortedFields.Add(sortDescription);
            
        }
    }
}
