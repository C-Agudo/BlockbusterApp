using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.CountryAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Country
{
    public class FindCountryUseCase : IUseCase
    {
        private ICountryRepository countryRepository;
        private CountryConverter countryConverter;
        private CountryFinderValidator countryFinderValidator;

        public FindCountryUseCase
        (
            ICountryRepository countryRepository, 
            CountryConverter countryConverter,
            CountryFinderValidator countryFinderValidator
        )
        {
            this.countryRepository = countryRepository;
            this.countryConverter = countryConverter;
            this.countryFinderValidator = countryFinderValidator;
        }

        public IResponse Execute(IRequest req)
        {
            FindCountryRequest request = req as FindCountryRequest;

            Domain.CountryAggregate.Country country = countryRepository.FindCountryByCode(new CountryCode(request.CountryCode));
            countryFinderValidator.Validate(new CountryCode(country.GetCode()));
            return countryConverter.Convert(country);
        }
    }
}
