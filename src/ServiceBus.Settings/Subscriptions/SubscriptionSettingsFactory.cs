using Microsoft.Azure.ServiceBus;
using ServiceBus.Contracts;

namespace ServiceBus.Factories.Subscriptions
{
   public static class SubscriptionSettingsFactory
   {
      public static ISubscriptionSettings CreateSubsriptionSettings(string connectionString, string subscription, ReceiveMode receiveMode)
      {
         return new SubscriptionSettings
         {
            ConnectionString = connectionString,
            Subscription = subscription,
            ReceiveMode = receiveMode
         };
      }
   }
}