using System.Collections;
using System.Configuration;
using AzureBlobManager;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Collections;
using Microsoft.Samples.ServiceHosting.StorageClient;

namespace Infragistics.Guidance.Aqua.DataClient.Commands
{
    public class GetLibraryItemsCommand: BaseDataCommand<DiagnosisLibraryItemCollection>
    {
        private string accountName;
        private string sharedKey;
        private string blobStorageEndPoint;
        protected override object ProcessCommand(Infragistics.Guidance.Aqua.Model.Framework.CommandCriteria criteria)
        {
            accountName = ConfigurationManager.AppSettings["AccountName"].ToString();
            sharedKey = ConfigurationManager.AppSettings["SharedKey"].ToString();
            blobStorageEndPoint = ConfigurationManager.AppSettings["BlobStorageEndPoint"].ToString();
            string container = "medicalimages";
            BlobManager blobManager = new BlobManager();          
            var blobs = blobManager.ListBlobs(container, blobStorageEndPoint, accountName, sharedKey);
            IEnumerator e = blobs.GetEnumerator();
            DiagnosisLibraryItemCollection libraryItems = new DiagnosisLibraryItemCollection();
            while(e.MoveNext())
            {
                DiagnosisLibraryItem libraryItem = new DiagnosisLibraryItem
                {
                    ContentType = ((BlobProperties)e.Current).ContentType,
                    ItemUri = ((BlobProperties)e.Current).Uri,
                    Name = ((BlobProperties)e.Current).Name,
                    LastModifiedTime = ((BlobProperties)e.Current).LastModifiedTime
                };
                libraryItems.Add(libraryItem);
            }
            
            return libraryItems;
        }
        
    }
}
