using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infrastructure.Security.Authentication.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Token.Delete
{
    public class DeleteTokenUseCase : IUseCase
    {
        private ITokenRepository tokenRepository;
        private DeleteTokenConverter tokenConverter;
        private IJWTDecoder decoder;
        public DeleteTokenUseCase
        (
            ITokenRepository tokenRepository,
            DeleteTokenConverter tokenConverter,
            IJWTDecoder decoder
        )
        {
            this.tokenRepository = tokenRepository;
            this.tokenConverter = tokenConverter;
            this.decoder = decoder;
        }
        public IResponse Execute(IRequest req)
        {
            DeleteTokenRequest request = req as DeleteTokenRequest;
            string userId = decoder.DecodeUserId(request.Hash);
            tokenRepository.Delete(userId);
            return tokenConverter.Convert();
        }
    }
}
