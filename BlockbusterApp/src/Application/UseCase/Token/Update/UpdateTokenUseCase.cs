using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Infrastructure.Service.Token;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infrastructure.Security.Authentication.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Update
{
    public class UpdateTokenUseCase : IUseCase
    {
        private TokenAdapter tokenAdapter;
        private ITokenFactory tokenFactory;
        private ITokenRepository tokenRepository;
        private UpdateTokenConverter tokenConverter;
        private IJWTDecoder decoder;
        public UpdateTokenUseCase
        (
            TokenAdapter tokenAdapter,
            ITokenFactory tokenFactory,
            ITokenRepository tokenRepository,
            UpdateTokenConverter tokenConverter,
            IJWTDecoder decoder
        )
        {
            this.tokenAdapter = tokenAdapter;
            this.tokenFactory = tokenFactory;
            this.tokenRepository = tokenRepository;
            this.tokenConverter = tokenConverter;
            this.decoder = decoder;
        }
        public IResponse Execute(IRequest req)
        {
            UpdateTokenRequest request = req as UpdateTokenRequest;
            TokenUserId tokenUserId = decoder.DecodeUserId(request.Token);
            TokenHash tokenHash = TokenHash.Create(request.Token);
            Domain.TokenAggregate.Token token = Domain.TokenAggregate.Token.Create(tokenHash, tokenUserId);
            tokenRepository.Update(token);
            return tokenConverter.Convert(token);
        }
    }
}
