using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Infrastructure.Service.Token;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token
{
    public class CreateTokenUseCase : IUseCase
    {
        private TokenAdapter tokenAdapter;
        private ITokenFactory tokenFactory;
        private ITokenRepository tokenRepository;
        private TokenConverter tokenConverter;
        public CreateTokenUseCase
        (
            TokenAdapter tokenAdapter,
            ITokenFactory tokenFactory,
            ITokenRepository tokenRepository,
            TokenConverter tokenConverter
        )
        {
            this.tokenAdapter = tokenAdapter;
            this.tokenFactory = tokenFactory;
            this.tokenRepository = tokenRepository;
            this.tokenConverter = tokenConverter;

        }
        public IResponse Execute(IRequest req)
        {
            CreateTokenRequest request = req as CreateTokenRequest;

            Dictionary<string, string> payload = this.tokenAdapter.FindPayloadFromEmailAndPassword(request.Email, request.Password);
            //check if the user has token
            Domain.TokenAggregate.Token token = this.tokenFactory.Create(payload);
            this.tokenRepository.Add(token);
            return this.tokenConverter.Convert(token);
        }
    }
}
