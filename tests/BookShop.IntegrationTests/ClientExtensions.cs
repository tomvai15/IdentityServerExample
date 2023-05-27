using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;

namespace BookShop.IntegrationTests
{
    public static class  ClientExtensions
    {
        public static async Task LoginAsValidUser(this CustomHttpClient client)
        {
            await client.AddJwtToken("client_credentials", "myApi.read", "cwm.client", "secret");
        }

        public static async Task AddJwtToken(this CustomHttpClient client, string grantType, string scope, string clientId, string clientSecret)
        {
            string uri = "connect/token";

            HttpClient httpClient = new HttpClient();
            // get from appsettings
            httpClient.BaseAddress = new Uri("https://localhost:7283/");

            var formData = new Dictionary<string, string>
            {
                { "grant_type", grantType },
                { "scope", scope },
                { "client_id", clientId },
                { "client_secret", clientSecret }
            };

            // Create the form content
            var formContent = new FormUrlEncodedContent(formData);

            // Make the HTTP request
            HttpResponseMessage response = await httpClient.PostAsync(uri, formContent);

            string content = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<LoginResponse>(content);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            client.AddBearerToken(responseData.AccessToken);
        }

        public static CustomHttpClient GetCustomHttpClient(this WebApplicationFactory<Program> factory)
        {
            return new CustomHttpClient(factory.CreateClient());
        }
    }
}
