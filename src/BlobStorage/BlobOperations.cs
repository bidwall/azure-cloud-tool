using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlobStorage.Contracts;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BlobStorage
{
   public class BlobOperations
   {
      private readonly CloudBlobDirectory _cloudBlobDirectory;

      public BlobOperations(IBlobSettings settings)
      {
         var cloudStorageAccount = CloudStorageAccount.Parse(settings.ConnectionString);

         var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
         var cloudBlobContainer = cloudBlobClient.GetContainerReference(settings.ContainerName);
         _cloudBlobDirectory = cloudBlobContainer.GetDirectoryReference(settings.DirectoryName);
      }

      public IEnumerable<IListBlobItem> GetBlobs(string path)
      {
         return _cloudBlobDirectory.ListBlobs(true);
      }

      public async Task UploadTextToBlobAsync(string blobName, string content)
      {
         var blockBlobReference = _cloudBlobDirectory.GetBlockBlobReference(blobName);
         await blockBlobReference.UploadTextAsync(content);
      }

      public async Task<bool> DoesFileExistsAsync(string blobName)
      {
         var blobReference = _cloudBlobDirectory.GetBlobReference(blobName);
         return await blobReference.ExistsAsync();
      }

      public bool DoesFileExtensionExists(string extension)
      {
         return _cloudBlobDirectory.ListBlobs(true).OfType<CloudBlockBlob>().Any(x => x.Name.EndsWith($".{extension}"));
      }
   }
}