using System;
using Newtonsoft.Json;
using ServiceBus.Contracts;

namespace ServiceBus.Factories.Messages
{
   public static class MessageFactory
   {
      public static IMessage CreateMessage()
      {
         return new Message
         {
            Payload = JsonConvert.SerializeObject(new { message = "document" }),
            TimeToLive = TimeSpan.FromDays(1)
         };
      }

      public static IMessage CreateMessageWithArray()
      {
         return new Message
         {
            Payload = JsonConvert.SerializeObject(new []{ new { message = "document1" }, new { message = "document2" } }),
            TimeToLive = TimeSpan.FromDays(1)
         };
      }
   }
}