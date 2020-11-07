using BlockbusterApp.src.Shared.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate.Event
{
    public class UserSignedUpEvent : DomainEvent
    {
        public UserSignedUpEvent(string aggregateId, Dictionary<string, string> body) : base(aggregateId, body)
        {

        }

        public override string Name()
        {
            return "user_signed_up";
        }

        protected override Dictionary<string, string> Rules()
        {
            Dictionary<string, string> rules = new Dictionary<string, string>();
            
            rules.Add("email", "string");
            rules.Add("firstname", "string");
            rules.Add("lastname", "string");
            rules.Add("role", "string");           

            return rules;
        }
    }
}
