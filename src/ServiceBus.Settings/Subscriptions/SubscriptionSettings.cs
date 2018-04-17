using Microsoft.Azure.ServiceBus;
using ServiceBus.Contracts;

namespace ServiceBus.Factories.Subscriptions
{
   public class SubscriptionSettings : ISubscriptionSettings
   {
      public string ConnectionString { get; set; }
      public string Topic { get; set; }
      public string Subscription { get; set; }
      public ReceiveMode ReceiveMode { get; set; }
   }
}