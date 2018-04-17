using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Security
{
   public static class AccessTokenProvider
   {
      public static async Task<string> GetAccessTokenAsync(string authority, string resourceUri, ClientCredential clientCredential)
      {
         var authenticationContext = new AuthenticationContext(authority);
         var result = await authenticationContext.AcquireTokenAsync(resourceUri, clientCredential);
         return result.AccessToken;
      }

      public static async Task<string> GetAccessTokenAsync(string authorityUri, string resourceUri, ClientAssertionCertificate clientAssertionCertificate)
      {
         var authenticationContext = new AuthenticationContext(authorityUri);
         var tokenSilentAsync = await authenticationContext.AcquireTokenAsync(resourceUri, clientAssertionCertificate);
         return tokenSilentAsync.AccessToken;
      }
   }
}