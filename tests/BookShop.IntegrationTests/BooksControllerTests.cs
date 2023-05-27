using BookShop.Api;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace BookShop.IntegrationTests
{
    [Collection("Sequential")]
    public class BooksControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BooksControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetBooks_ValidUser_ReturnsBooks()
        {
            string uri = $"api/Books";
            var client = _factory.GetCustomHttpClient();
            await client.LoginAsValidUser();

            var response = await client.Get<IEnumerable<Book>>(uri);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}