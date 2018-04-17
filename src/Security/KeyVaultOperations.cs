using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;

namespace Security
{
   public class KeyVaultOperations
   {
      private readonly string _keyVaultBaseUrl;
      private readonly KeyVaultClient _keyVaultClient;

      public KeyVaultOperations(string keyVaultBaseUrl)
      {
         _keyVaultBaseUrl = keyVaultBaseUrl;

         // uses Microsoft.Azure.Services.AppAuthentication for service to service authentication
         _keyVaultClient = new KeyVaultClient(CredentialsProviderFactory.GetKeyvaultAuthenticationCallback());
      }

      public async Task<string> GetSecretAsync(string secretName)
      {
         var secretBundle = await _keyVaultClient.GetSecretAsync(_keyVaultBaseUrl, secretName);
         return secretBundle.Value;
      }

      public async Task<X509Certificate2> GetCertificateAsync(string certificateName)
      {
         var secretBundle = await _keyVaultClient.GetSecretAsync(_keyVaultBaseUrl, certificateName);
         return new X509Certificate2(Convert.FromBase64String(secretBundle.Value));
      }
   }
}