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
//using Microsoft.Samples.ServiceHosting.StorageClient;
using Infragistics.Guidance.Aqua.Model;
using System.Net;
using System.IO;
using System.Windows.Markup;
using System.Xml;
using System.Xml.Linq;
using System.IO.Packaging;
using System.Windows.Xps.Packaging;
using Infragistics.Guidance.Aqua.Client.ViewModel;
using Infragistics.Windows.Controls;
using Infragistics.Guidance.Aqua.DataClient.Commands;

namespace Infragistics.Guidance.Aqua.Client.View
{
    /// <summary>
    /// Interaction logic for DiagnosisSupportView.xaml
    /// </summary>
    public partial class DiagnosisSupportView : UserControl
    {
        private DiagnosisSupportViewModel diagnosisSupportViewModel;
        LiveContactViewModel SelectedContact;
        public DiagnosisSupportView()
        {
            InitializeComponent();

			this.Loaded += new RoutedEventHandler(DiagnosisSupportView_Loaded);
           
        }

		void DiagnosisSupportView_Loaded(object sender, RoutedEventArgs e)
		{
			this.diagnosisSupportViewModel = this.DataContext as DiagnosisSupportViewModel;
		}

        private void DocumentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (DocumentsComboBox.SelectedIndex != -1)
            {
                Uri uri = ((DiagnosisLibraryItem)this.DocumentsComboBox.SelectedItem).ItemUri;
                string Name = ((DiagnosisLibraryItem)this.DocumentsComboBox.SelectedItem).Name;
                DownloadXpsDoc(uri,Name);
            }            
        }

        private void DownloadXpsDoc(Uri theUri,string Name)
        {          
            System.Net.WebClient client = new WebClient();
            try
            {
                //Download the document
                byte[] XpsBytes = client.DownloadData(theUri);
                MemoryStream xpsStream = new MemoryStream(XpsBytes);
                Package package = Package.Open(xpsStream);
                //Create URI for the package
                Uri packageUri = new Uri(theUri.ToString());
                //Need to add the Package to the PackageStore
                PackageStore.AddPackage(packageUri, package);
                //Create instance of XpsDocument 
                XpsDocument document = new XpsDocument(package, CompressionOption.Maximum, theUri.ToString());
                //Do the operation on document here
                //Here I am viewing the document in the DocViewer
                FixedDocumentSequence fixedDocumentSequence = document.GetFixedDocumentSequence();
                //To view in the DocViewer
                DocReader.Document = fixedDocumentSequence as IDocumentPaginatorSource;
                //Remember to keep the Package object in PackageStore until all operations complete on document.
                //Remove the package from store
                PackageStore.RemovePackage(packageUri);
                //Close the Document
                document.Close();  

            }
            catch (XamlParseException ex)
            {
                MessageBox.Show(ex.Message, "XamlParseException", MessageBoxButton.OK);
            }
            
        }

       

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
			this.diagnosisSupportViewModel.GetChatResponses();
        }

	   #region Buttons
	   private void btnNavigatePrev_Click(object sender, System.Windows.RoutedEventArgs e)
	   {
		   ImageCarousel.ScrollInfo.LineLeft();
	   }

	   private void btnNavigateNext_Click(object sender, System.Windows.RoutedEventArgs e)
	   {
		   ImageCarousel.ScrollInfo.LineRight();
	   }
	   #endregion Buttons

		private void ContactsChatTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			SelectedContact = e.AddedItems[0] as LiveContactViewModel;
			if (SelectedContact != null && this.diagnosisSupportViewModel != null)
			{
				this.diagnosisSupportViewModel.SelectedContact = SelectedContact;
			}
        }
    }
}
    