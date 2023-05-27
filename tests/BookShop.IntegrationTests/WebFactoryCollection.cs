using Microsoft.AspNetCore.Mvc.Testing;

namespace BookShop.IntegrationTests
{
    [CollectionDefinition("Sequential")]
    public class WebFactoryCollection : ICollectionFixture<WebApplicationFactory<Program>>
    {
    }
}
