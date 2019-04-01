﻿#pragma checksum "..\..\..\View\TestResultsView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92CF392CDE18A8528B1498F1987C159534CF8A6F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Infragistics.Guidance.Aqua.Client;
using Infragistics.Guidance.Aqua.Client.Converters;
using Infragistics.Shared;
using Infragistics.Windows;
using Infragistics.Windows.Chart;
using Infragistics.Windows.Controls;
using Infragistics.Windows.Controls.Markup;
using Infragistics.Windows.DataPresenter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Infragistics.Guidance.Aqua.Client.View {
    
    
    /// <summary>
    /// TestResultsView
    /// </summary>
    public partial class TestResultsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 149 "..\..\..\View\TestResultsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Infragistics.Windows.Controls.XamTabControl XamTabTestResults;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\View\TestResultsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Infragistics.Windows.DataPresenter.XamDataGrid xdgTests;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\View\TestResultsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Infragistics.Windows.Controls.XamCarouselListBox XCLBRadiology;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\View\TestResultsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path horizontalPath;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\View\TestResultsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNavigatePrev;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\..\View\TestResultsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNavigateNext;
        
        #line default
        #line hidden
        
        
        #line 275 "..\..\..\View\TestResultsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTestType;
        
        #line default
        #line hidden
        
        
        #line 276 "..\..\..\View\TestResultsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTestTimestamp;
        
        #line default
        #line hidden
        
        
        #line 292 "..\..\..\View\TestResultsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Infragistics.Windows.Chart.XamChart XCVitalsMaximized;
        
        #line default
        #line hidden
        
        
        #line 320 "..\..\..\View\TestResultsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Infragistics.Windows.Chart.Series Series1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Infragistics.Guidance.Aqua;component/view/testresultsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\TestResultsView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.XamTabTestResults = ((Infragistics.Windows.Controls.XamTabControl)(target));
            
            #line 149 "..\..\..\View\TestResultsView.xaml"
            this.XamTabTestResults.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.XamTabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.xdgTests = ((Infragistics.Windows.DataPresenter.XamDataGrid)(target));
            return;
            case 3:
            this.XCLBRadiology = ((Infragistics.Windows.Controls.XamCarouselListBox)(target));
            return;
            case 4:
            this.horizontalPath = ((System.Windows.Shapes.Path)(target));
            return;
            case 5:
            this.btnNavigatePrev = ((System.Windows.Controls.Button)(target));
            
            #line 196 "..\..\..\View\TestResultsView.xaml"
            this.btnNavigatePrev.Click += new System.Windows.RoutedEventHandler(this.btnNavigatePrev_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnNavigateNext = ((System.Windows.Controls.Button)(target));
            
            #line 236 "..\..\..\View\TestResultsView.xaml"
            this.btnNavigateNext.Click += new System.Windows.RoutedEventHandler(this.btnNavigateNext_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtTestType = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.txtTestTimestamp = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.XCVitalsMaximized = ((Infragistics.Windows.Chart.XamChart)(target));
            return;
            case 10:
            this.Series1 = ((Infragistics.Windows.Chart.Series)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

