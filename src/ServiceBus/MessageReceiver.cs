using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using ServiceBus.Contracts;

namespace ServiceBus
{
   public class MessageReceiver
   {
      private readonly SubscriptionClient _subscriptionClient;
      private Action<Message> _onMessage;

      public MessageReceiver(ISubscriptionSettings settings)
      {
         _subscriptionClient = new SubscriptionClient(settings.ConnectionString, settings.Topic, settings.Subscription, settings.ReceiveMode);
      }

      public void Start(Action<Message> onMessage)
      {
         _onMessage = onMessage;
         var onMessageOptions = new MessageHandlerOptions(args => Task.CompletedTask) {AutoComplete = false, MaxConcurrentCalls = 1};
         _subscriptionClient.RegisterMessageHandler(ProcessMessages, onMessageOptions);
      }

      private async Task ProcessMessages(Message message, CancellationToken cancellationToken)
      {
         _onMessage(message);
         await Task.CompletedTask;
      }

      public async Task StopAsync()
      {
         await _subscriptionClient.CloseAsync();
      }
   }
}