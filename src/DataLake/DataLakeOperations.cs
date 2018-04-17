using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.DataLake.Store;
using Microsoft.Rest;

namespace DataLake
{
   public class DataLakeOperations
   {
      private readonly AdlsClient _adlsClient;

      public DataLakeOperations(string accountFqdn, ServiceClientCredentials serviceClientCredentials)
      {
         _adlsClient = AdlsClient.CreateClient(accountFqdn, serviceClientCredentials);
      }

      public async Task AddAsync(string path, string content)
      {
         using (var streamWriter = new StreamWriter(_adlsClient.CreateFile(path, IfExists.Overwrite)))
         {
            await streamWriter.WriteAsync(content);
         }
      }

      public bool Exists(string path)
      {
         return _adlsClient.CheckExists(path);
      }

      public long Count(string path)
      {
         return _adlsClient.GetContentSummary(path).FileCount;
      }

      public async Task DeleteAsync(string path)
      {
         await _adlsClient.DeleteAsync(path);
      }

      public async Task DeleteRecursiveAsync(string path)
      {
         await _adlsClient.DeleteRecursiveAsync(path);
      }
   }
}