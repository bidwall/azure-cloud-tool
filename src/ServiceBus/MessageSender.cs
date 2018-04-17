using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using ServiceBus.Contracts;

namespace ServiceBus
{
   public class MessageSender
   {
      private readonly TopicClient _topicClient;

      public MessageSender(ITopicSettings settings)
      {
         _topicClient = new TopicClient(settings.ConnectionString, settings.Topic);
      }

      public async Task SendMessageAsync(IMessage data)
      {
         var message = new Message(Encoding.UTF8.GetBytes(data.Payload))
         {
            TimeToLive = data.TimeToLive
         };

         foreach (var header in data.Headers)
         {
            message.UserProperties.Add(header.Key, header.Value);
         }
         
         await _topicClient.SendAsync(message);
      }

      public async Task CloseAsync()
      {
         await _topicClient.CloseAsync();
      }
   }
}