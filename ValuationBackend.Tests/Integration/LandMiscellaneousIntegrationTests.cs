using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ValuationBackend.Data;
using ValuationBackend.Models;
using Xunit;

namespace ValuationBackend.Tests.Integration
{
    public class LandMiscellaneousIntegrationTests : IClassFixture<TestWebApplicationFactory<Program>>
    {
        private readonly TestWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public LandMiscellaneousIntegrationTests(TestWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/api/landmiscellaneous/all");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.NotNull(content);
        }

        [Fact]
        public async Task GetPaginated_ReturnsValidPaginationStructure()
        {
            // Act
            var response = await _client.GetAsync("/api/landmiscellaneous/paginated?pageNumber=1&pageSize=10");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(content);
            var root = document.RootElement;

            Assert.True(root.TryGetProperty("records", out _));
            Assert.True(root.TryGetProperty("totalCount", out _));
            Assert.True(root.TryGetProperty("pageNumber", out _));
            Assert.True(root.TryGetProperty("pageSize", out _));
            Assert.True(root.TryGetProperty("totalPages", out _));
            Assert.True(root.TryGetProperty("sortBy", out _));
        }

        [Fact]
        public async Task GetPaginated_WithSortParameter_ReturnsSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/landmiscellaneous/paginated?pageNumber=1&pageSize=10&sortBy=PlanType");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(content);
            var root = document.RootElement;

            Assert.True(root.TryGetProperty("sortBy", out var sortByProperty));
            Assert.Equal("PlanType", sortByProperty.GetString());
        }

        [Fact]
        public async Task Search_ReturnsValidSearchStructure()
        {
            // Act
            var response = await _client.GetAsync("/api/landmiscellaneous/search?searchTerm=test&pageNumber=1&pageSize=10");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(content);
            var root = document.RootElement;

            Assert.True(root.TryGetProperty("records", out _));
            Assert.True(root.TryGetProperty("totalCount", out _));
            Assert.True(root.TryGetProperty("pageNumber", out _));
            Assert.True(root.TryGetProperty("pageSize", out _));
            Assert.True(root.TryGetProperty("totalPages", out _));
            Assert.True(root.TryGetProperty("searchTerm", out _));
            Assert.True(root.TryGetProperty("sortBy", out _));
        }

        [Fact]
        public async Task Search_WithEmptySearchTerm_ReturnsSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/landmiscellaneous/search?searchTerm=&pageNumber=1&pageSize=10");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(content);
            var root = document.RootElement;

            Assert.True(root.TryGetProperty("searchTerm", out var searchTermProperty));
            Assert.Equal("", searchTermProperty.GetString());
        }

        [Fact]
        public async Task GetPaginated_WithInvalidPageNumber_ReturnsDefaults()
        {
            // Act
            var response = await _client.GetAsync("/api/landmiscellaneous/paginated?pageNumber=0&pageSize=10");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(content);
            var root = document.RootElement;

            Assert.True(root.TryGetProperty("pageNumber", out var pageNumberProperty));
            Assert.Equal(1, pageNumberProperty.GetInt32()); // Should default to 1
        }

        [Fact]
        public async Task GetPaginated_WithInvalidPageSize_ReturnsDefaults()
        {
            // Act
            var response = await _client.GetAsync("/api/landmiscellaneous/paginated?pageNumber=1&pageSize=0");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(content);
            var root = document.RootElement;

            Assert.True(root.TryGetProperty("pageSize", out var pageSizeProperty));
            Assert.Equal(10, pageSizeProperty.GetInt32()); // Should default to 10
        }

        [Fact]
        public async Task Search_WithInvalidPagination_ReturnsDefaults()
        {
            // Act
            var response = await _client.GetAsync("/api/landmiscellaneous/search?searchTerm=test&pageNumber=0&pageSize=0");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(content);
            var root = document.RootElement;

            Assert.True(root.TryGetProperty("pageNumber", out var pageNumberProperty));
            Assert.True(root.TryGetProperty("pageSize", out var pageSizeProperty));
            Assert.Equal(1, pageNumberProperty.GetInt32()); // Should default to 1
            Assert.Equal(10, pageSizeProperty.GetInt32()); // Should default to 10
        }

        [Fact]
        public async Task GetAll_WithSortParameter_ReturnsSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/landmiscellaneous/all?sortBy=PlanType");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.NotNull(content);

            // Verify it's a valid JSON array
            using var document = JsonDocument.Parse(content);
            Assert.Equal(JsonValueKind.Array, document.RootElement.ValueKind);
        }

        [Fact]
        public async Task AllEndpoints_ReturnValidJsonContentType()
        {
            // Test all endpoints return JSON
            var endpoints = new[]
            {
                "/api/landmiscellaneous/all",
                "/api/landmiscellaneous/paginated?pageNumber=1&pageSize=10",
                "/api/landmiscellaneous/search?searchTerm=test&pageNumber=1&pageSize=10"
            };

            foreach (var endpoint in endpoints)
            {
                // Act
                var response = await _client.GetAsync(endpoint);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
            }
        }
    }
}
