

namespace OrderingShop.Tests.Api.Controllers
{
    public class ProductControllerTests: ApiTestBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        private readonly ProductController _productController;

        public ProductControllerTests()
        {
            _productService = A.Fake<IProductService>();
            _logger = A.Fake<ILogger<ProductController>>();
            _productController = new ProductController(
                _logger,
                _productService
            );
        }

        [Fact]
        public async Task GetAll_Should_Get_All_Products()
        {
            var response = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Description = "Fake_Description",
                    Name = "Fake_Product",
                    Price = 20m,
                    Stock = 20
                }
            };

            A.CallTo(() =>
                _productService.GetAllProductsAsync()
            ).Returns(response);

            // act
            var result = await _productController.GetAllProducts();

            // assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);

            var actionResult = (OkObjectResult)result.Result;
            Assert.Equal(200, actionResult.StatusCode);

            var dataResult = ((OkObjectResult)result.Result).Value as IEnumerable<ProductDto>;
            Assert.NotNull(dataResult);
            dataResult.Should().NotBeNull();
            dataResult.Count().Should().Be(1);
        }
    }
}