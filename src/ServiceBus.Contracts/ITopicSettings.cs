namespace ServiceBus.Contracts
{
   public interface ITopicSettings
   {
      string ConnectionString { get; set; }
      string Topic { get; set; }
   }
}