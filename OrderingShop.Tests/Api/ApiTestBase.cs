
namespace OrderingShop.Tests.Api
{
    public abstract class ApiTestBase
    {
        protected static readonly string validProductId = Guid.NewGuid().ToString();

        protected HttpContextAccessor httpContextAccessor;

        protected ApiTestBase()
        {
            var context = new HttpContextAccessor
            {
                HttpContext = new DefaultHttpContext()
            };

            context.HttpContext.Request.Headers["Authorization"] = "Baerer some_fake";
         
            var fakeUser = A.Fake<ClaimsPrincipal>();
            A.CallTo(() => fakeUser.Identity.IsAuthenticated).Returns(true);
            context.HttpContext.User = fakeUser;

            httpContextAccessor = context;
        }
    }
}
