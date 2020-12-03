using BlockbusterApp.src.Domain.TokenAggregate.Event;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.TokenAggregate
{
    public class Token : AggregateRoot
    {
        public TokenHash hash { get; set; }
        [Key]
        public TokenUserId userId { get; }
        public TokenCreatedAt createdAt { get; }
        public TokenUpdatedAt updatedAt { get; set; }

        private Token
        (
            TokenHash hash,
            TokenUserId userId,
            TokenCreatedAt createdAt,
            TokenUpdatedAt updatedAt
        )
        {
            this.hash = hash;
            this.userId = userId;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public static Token Create(TokenHash hash, TokenUserId userId)
        {
            TokenCreatedAt createdAt = new TokenCreatedAt(DateTime.Now);
            TokenUpdatedAt updatedAt = new TokenUpdatedAt(DateTime.Now);

            Token token = new Token(hash, userId, createdAt, updatedAt);

            token.Record(new TokenCreatedEvent(
                token.userId.GetValue(),
                new Dictionary<string, string>()
                {
                    ["hash"] = token.hash.GetValue(),
                    ["user_id"] = token.userId.GetValue(),
                    ["created_at"] = token.createdAt.GetValue().ToString(),
                    ["updated_at"] = token.updatedAt.GetValue().ToString()
                }
            ));

            return token;
        }

        public void SetTokenHash(TokenHash hash)
        {
            this.hash = hash;
        }
        public void SetTokenUpdatedAt(TokenUpdatedAt updatedAt)
        {
            this.updatedAt = updatedAt;
        }
    }
}
