using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Infrastructure.Service.Token;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
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
        public UpdateTokenUseCase
        (
            TokenAdapter tokenAdapter,
            ITokenFactory tokenFactory,
            ITokenRepository tokenRepository,
            UpdateTokenConverter tokenConverter
        )
        {
            this.tokenAdapter = tokenAdapter;
            this.tokenFactory = tokenFactory;
            this.tokenRepository = tokenRepository;
            this.tokenConverter = tokenConverter;
        }
        public IResponse Execute(IRequest req)
        {
            UpdateTokenRequest request = req as UpdateTokenRequest;
            Dictionary<string, string> payload = this.tokenAdapter.FindPayloadFromEmailAndPassword(request.Email, request.Password);
            Domain.TokenAggregate.Token token = this.tokenFactory.Create(payload);
            tokenRepository.Update(token);
            return tokenConverter.Convert(token);
        }
    }
}
