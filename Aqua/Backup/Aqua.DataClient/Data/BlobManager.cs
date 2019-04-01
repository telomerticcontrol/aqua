using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

// add the StorageClient assebly which wraps the REST calls the the cloud service
using Microsoft.Samples.ServiceHosting.StorageClient;

namespace AzureBlobManager
{
    class BlobManager
    {
        #region Manage Blob Containers
        // ************************************
        // Get Blob Containers
        // ************************************        
        public IEnumerable<BlobContainer> ListContainers(string BlobEndPoint, 
                                string Account, string SharedKey)
        {
            StorageAccountInfo AccountInfo = 
                new StorageAccountInfo(new Uri(BlobEndPoint), 
                    null, Account, SharedKey);
            
            var blobStore = BlobStorage.Create(AccountInfo);
            return blobStore.ListBlobContainers();
        }

        // ************************************
        // Create a new Blob Container
        // ************************************
        public void CreateContainer(string ContainerName, bool isPublic, 
            string BlobEndPoint, string Account, string SharedKey)
        {
            StorageAccountInfo AccountInfo =
                new StorageAccountInfo(new Uri(BlobEndPoint),
                    null, Account, SharedKey); 
            
            var blobStore = BlobStorage.Create(AccountInfo);

            ContainerAccessControl accessControl = isPublic ?
                ContainerAccessControl.Public : ContainerAccessControl.Private;

            blobStore.GetBlobContainer(ContainerName).CreateContainer(null, accessControl);
        }

        // **************************
        // Delete Blob Container
        // **************************
        public  void DeleteContainer(string ContainerName, 
            string BlobEndPoint, string Account, string SharedKey)
        {
            StorageAccountInfo AccountInfo =
                new StorageAccountInfo(new Uri(BlobEndPoint),
                    null, Account, SharedKey);

            var blobStore = BlobStorage.Create(AccountInfo);

            blobStore.GetBlobContainer(ContainerName).DeleteContainer();
        } 
        #endregion

        #region Manage Blob Container Items

        // *********************************************************
        // Create a new Blob in a Specific Blob Container
        // *********************************************************
            public void CreateBlob(string ContainerName, string FileName, 
                string BlobEndPoint, string Account, string SharedKey)
            {
                StorageAccountInfo AccountInfo = 
                    new StorageAccountInfo(new Uri(BlobEndPoint), null, Account, SharedKey);
                
                var blobStore = BlobStorage.Create(AccountInfo);
                
                var container = blobStore.GetBlobContainer(ContainerName);

                BlobProperties props = new BlobProperties(System.IO.Path.GetFileName(FileName));
                
                BlobContents blobContents = 
                    new BlobContents(new System.IO.FileStream(FileName, FileMode.Open));
                
                container.CreateBlob(props, blobContents, true);
            }

        // *********************************************************
        // Delete a Blob in a Specific Blob Container
        // *********************************************************
        public  void DeleteBlob(string ContainerName, string BlobName, 
            string BlobEndPoint, string Account, string SharedKey)
        {
            StorageAccountInfo AccountInfo = 
                new StorageAccountInfo(new Uri(BlobEndPoint), null, Account, SharedKey);
            
            var blobStore = BlobStorage.Create(AccountInfo);

            var container = blobStore.GetBlobContainer(ContainerName);
            
            if (container.DoesBlobExist(BlobName)) {
                container.DeleteBlob(BlobName);
          }
        }

        // *********************************************************
        // Enumerate all Blobs in a Specific Blob Container
        // *********************************************************
        public IEnumerable<Object> ListBlobs(string ContainerName, 
            string BlobEndPoint, string Account, string SharedKey)
        {
            StorageAccountInfo AccountInfo = new StorageAccountInfo(new Uri(BlobEndPoint), null, Account, SharedKey);
            var blobStore = BlobStorage.Create(AccountInfo);
            var container = blobStore.GetBlobContainer(ContainerName);
            return container.ListBlobs(string.Empty, false);
        }
        
        #endregion
    }
}
