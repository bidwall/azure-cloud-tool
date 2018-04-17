using System;
using System.Collections.Generic;

namespace ServiceBus.Contracts
{
   public interface IMessage
   {
      string Payload { get; set; }
      Dictionary<string, string> Headers { get; set; }
      TimeSpan TimeToLive { get; set; }
   }
}