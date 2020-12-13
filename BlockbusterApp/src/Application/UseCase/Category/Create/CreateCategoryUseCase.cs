using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Category.Create
{
    public class CreateCategoryUseCase : IUseCase
    {
        private ICategoryFactory categoryFactory;
        private ICategoryRepository categoryRepository;
        private CreateCategoryConverter converter;
        public CreateCategoryUseCase
        (
            ICategoryFactory categoryFactory,
            ICategoryRepository categoryRepository,
            CreateCategoryConverter converter
        )
        {
            this.categoryFactory = categoryFactory;
            this.categoryRepository = categoryRepository;
           this.converter =  converter;
        }
        public IResponse Execute(IRequest req)
        {
            CreateCategoryRequest request = req as CreateCategoryRequest;
            Domain.CategoryAggregate.Category category = categoryFactory.Create(request.categoryId, request.categoryName);
            categoryRepository.Add(category);
            IResponse response = converter.Convert();
            return response;
        }
    }
}
