using BlockbusterApp.src.Shared.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.TokenAggregate.Event
{
    public class TokenCreatedEvent : DomainEvent
    {
        public TokenCreatedEvent(string aggregateId, Dictionary<string, string> body) : base(aggregateId, body)
        {

        }

        public override string Name()
        {
            return "token_created";
        }

        protected override Dictionary<string, string> Rules()
        {
            Dictionary<string, string> rules = new Dictionary<string, string>();

            rules.Add("hash", "string");
            rules.Add("user_id", "string");
            rules.Add("created_at", "string");
            rules.Add("updated_at", "string");

            return rules;
        }
    }
}
