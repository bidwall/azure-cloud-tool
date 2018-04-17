using ServiceBus.Contracts;

namespace ServiceBus.Factories.TopicSettings
{
   public static class TopicSettingsFactory
   {
      public static ITopicSettings CreateDevelopmentSettings(string connectionString, string topic)
      {
         return new TopicSettings
         {
            ConnectionString = connectionString,
            Topic = topic
         };
      }
   }
}