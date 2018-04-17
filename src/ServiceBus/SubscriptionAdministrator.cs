using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using ServiceBus.Contracts;

namespace ServiceBus
{
   public class SubscriptionAdministrator
   {
      private readonly SubscriptionClient _subscriptionClient;

      public SubscriptionAdministrator(ISubscriptionSettings settings)
      {
         _subscriptionClient = new SubscriptionClient(settings.ConnectionString, settings.Topic, settings.Subscription, settings.ReceiveMode);
      }

      public async Task AddRule(RuleDescription ruleDescription)
      {
         await _subscriptionClient.AddRuleAsync(ruleDescription);
      }

      public async Task RemoveRule(string ruleName)
      {
         await _subscriptionClient.RemoveRuleAsync(ruleName);
      }
   }
}