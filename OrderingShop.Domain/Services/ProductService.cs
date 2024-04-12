using OrderingShop.Domain.Dtos;
using OrderingShop.Domain.Interfaces;

namespace OrderingShop.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var result = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }
    }
}
