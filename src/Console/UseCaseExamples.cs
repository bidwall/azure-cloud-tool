using System.IO;
using System.Text;
using System.Threading.Tasks;
using BlobStorage;
using ConsoleApp.Pocos;
using DataLake;
using Microsoft.Azure.ServiceBus;
using Security;
using ServiceBus;
using ServiceBus.Factories.Messages;
using ServiceBus.Factories.Subscriptions;
using ServiceBus.Factories.TopicSettings;

namespace ConsoleApp
{
   public class UseCaseExamples
   {
      public static async Task KeyVault()
      {
         var keyvaultOperations = new KeyVaultOperations("someurl");

         var secret = await keyvaultOperations.GetSecretAsync("someSecretName");
         var certificate = await keyvaultOperations.GetCertificateAsync("someCertificateName");
      }

      public static async Task DataLake()
      {
         var tokenCredentials = await CredentialsProviderFactory.GetTokenCredentialsAsync(Constants.Resource.AzureDatalakeStore);
         var dataLakeOperations = new DataLakeOperations("someFqdn", tokenCredentials);

         const string path = "/some/path";
         var filePath = Path.Combine(path, "document.json");

         await dataLakeOperations.AddAsync(filePath, "{ \"message\" : \"document\" }");
         await dataLakeOperations.DeleteAsync(filePath);
         var count = dataLakeOperations.Count(path);
      }

      public static async Task BlobStorage()
      {
         var blobSettings = new SomeBlobSettings();
         var blobOperations = new BlobOperations(blobSettings);
         
         const string path = @"some/blobs";
         var filePath = Path.Combine(path, "blob.json");
         
         await blobOperations.UploadTextToBlobAsync(filePath, "{ \"message\" : \"document\" }");
         await blobOperations.DoesFileExistsAsync(filePath);
         var listBlobItems = blobOperations.GetBlobs(path);         
      }

      public static async Task ServiceBusTopicSender()
      {
         var keyvaultOperations = new KeyVaultOperations("someurl");
         
         var connectionString = await keyvaultOperations.GetSecretAsync("someSecretName");
         var topicName =  await keyvaultOperations.GetSecretAsync("someSecretName");
         var someTopicSetting = TopicSettingsFactory.CreateDevelopmentSettings(connectionString, topicName);
         var messageSender = new MessageSender(someTopicSetting);

         var message = MessageFactory.CreateMessage();
         await messageSender.SendMessageAsync(message);

         await messageSender.CloseAsync();
      }

      public static async Task ServiceBusTopicSubscriptionListner()
      {
         var keyvaultOperations = new KeyVaultOperations("someurl");

         var connectionString = await keyvaultOperations.GetSecretAsync("someSecretName");
         var subscriptionName = await keyvaultOperations.GetSecretAsync("someSecretName");

         var subscriptionSettings = SubscriptionSettingsFactory.CreateSubsriptionSettings(connectionString, subscriptionName, ReceiveMode.PeekLock);

         var messageReceiver = new MessageReceiver(subscriptionSettings);
         messageReceiver.Start(message =>
         {
            var payload = Encoding.UTF8.GetString(message.Body);
         });

         await messageReceiver.StopAsync();
      }      
   }
}