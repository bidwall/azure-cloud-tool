using ServiceBus.Contracts;

namespace ServiceBus.Factories.TopicSettings
{
   public class TopicSettings : ITopicSettings
   {
      public string ConnectionString { get; set; }
      public string Topic { get; set; }
   }
}