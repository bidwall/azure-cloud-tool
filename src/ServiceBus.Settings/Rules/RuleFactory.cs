using Microsoft.Azure.ServiceBus;

namespace ServiceBus.Settings.Rules
{
   public class RuleFactory
   {
      public static RuleDescription CreateHeaderEqualsRule(string name, string header, string requiredValue)
      {        
         return new RuleDescription(name, new SqlFilter($"{header} = '{requiredValue}'"));
      }
   }
}