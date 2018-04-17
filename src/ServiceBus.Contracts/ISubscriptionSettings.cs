using Microsoft.Azure.ServiceBus;

namespace ServiceBus.Contracts
{
   public interface ISubscriptionSettings : ITopicSettings
   {
      string Subscription { get; }

      ReceiveMode ReceiveMode { get; }
   }
}