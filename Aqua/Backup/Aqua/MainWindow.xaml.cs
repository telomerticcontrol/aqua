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
using Infragistics.Windows.TilePanel;
using Infragistics.Guidance.Aqua.Client.View;
using System.Configuration;

using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.IO;


namespace Infragistics.Guidance.Aqua.Client
{
	public partial class MainWindow : Window
	{
		#region Private Fields
		private MainWindowViewModel viewModel;
		private Storyboard showLoginStoryboard;
		private Storyboard hideLoginStoryboard;
		#endregion Private Fields
		
		public MainWindow()
		{
			InitializeComponent();
            
            string basePath = AppDomain.CurrentDomain.BaseDirectory.ToString();
            string path = FindAquaDirectory(basePath,Directory.GetDirectoryRoot(basePath));          
            AppDomain.CurrentDomain.SetData("DataDirectory", path + @"\SQLData");
            
            this.viewModel = new MainWindowViewModel(this.Dispatcher);
            this.showLoginStoryboard = this.Resources["sbShowLogin"] as Storyboard;
            this.hideLoginStoryboard = this.Resources["sbHideLogin"] as Storyboard;

            this.viewModel.LoginRequested += new EventHandler(OnViewModelLoginRequested);
            this.viewModel.LoginComplete += new EventHandler(OnViewModelLoginComplete);

			this.viewModel.Initialize();
			base.DataContext = this.viewModel;
						
			this.Loaded += new RoutedEventHandler(MainWindow_Loaded);			
			if (string.IsNullOrEmpty(this.Title))
				this.Title = "Aqua";

		}

		#region Event Handlers
       
       
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			

		}


		void OnViewModelLoginRequested(object sender, EventArgs e)
		{
			if (this.showLoginStoryboard != null)
			{
				this.showLoginStoryboard.Begin();
			}
		}

		void OnViewModelLoginComplete(object sender, EventArgs e)
		{

			// Set Cursor
			this.LiveLoginView1.Cursor = Cursors.Arrow;
			
			if (this.hideLoginStoryboard != null)
			{
				this.hideLoginStoryboard.Begin();
			}
		}
		#endregion Event Handlers

        #region Methods
        private string FindAquaDirectory(string basePath, string root)
        {
            while (!basePath.EndsWith("Aqua") && basePath != root)
            {
                basePath = Directory.GetParent(basePath).ToString();
            }

            return root == basePath ? string.Empty : Directory.GetParent(basePath).ToString();

        }
        #endregion
    }
}
