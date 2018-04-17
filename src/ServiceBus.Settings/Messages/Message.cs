using System;
using System.Collections.Generic;
using ServiceBus.Contracts;

namespace ServiceBus.Factories.Messages
{
   public class Message : IMessage
   {
      public string Payload { get; set; }
      public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
      public TimeSpan TimeToLive { get; set; }
   }
}