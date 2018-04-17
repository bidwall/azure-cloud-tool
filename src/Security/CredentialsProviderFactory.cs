using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace Security
{
   public static class CredentialsProviderFactory
   {
      public static async Task<TokenCredentials> GetTokenCredentialsAsync(string resource)
      {
         var azureServiceTokenProvider = new AzureServiceTokenProvider();
         var accessTokenAsync = await azureServiceTokenProvider.GetAccessTokenAsync(resource);

         return new TokenCredentials(accessTokenAsync);
      }

      public static ClientCredential GetClientCredentials(string clientId, string clientSecret)
      {
         return new ClientCredential(clientId, clientSecret);
      }

      public static KeyVaultClient.AuthenticationCallback GetKeyvaultAuthenticationCallback()
      {
         var azureServiceTokenProvider = new AzureServiceTokenProvider();
         return new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback);
      }

      public static async Task<string> GetAccessTokenAsync(string authorityUri, string resourceUri, ClientAssertionCertificate clientAssertionCertificate)
      {
         var authenticationContext = new AuthenticationContext(authorityUri);
         var tokenSilentAsync = await authenticationContext.AcquireTokenAsync(resourceUri, clientAssertionCertificate);
         return tokenSilentAsync.AccessToken;
      }
   }
}