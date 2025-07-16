using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValuationBackend.Controllers;
using ValuationBackend.Models;
using ValuationBackend.Services;
using Xunit;

namespace ValuationBackend.Tests.Controllers
{
    public class LandMiscellaneousControllerTests
    {
        private readonly Mock<ILandMiscellaneousService> _mockService;
        private readonly LandMiscellaneousController _controller;

        public LandMiscellaneousControllerTests()
        {
            _mockService = new Mock<ILandMiscellaneousService>();
            _controller = new LandMiscellaneousController(_mockService.Object);
        }

        #region GetAll Tests

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithLandMiscellaneousList()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>
            {
                new LandMiscellaneousMasterFile
                {
                    Id = 1,
                    MasterFileNo = 1001,
                    PlanType = "Subdivision",
                    PlanNo = "SP001",
                    RequestingAuthorityReferenceNo = "REF001",
                    Status = "Active",
                    Lots = 10
                },
                new LandMiscellaneousMasterFile
                {
                    Id = 2,
                    MasterFileNo = 1002,
                    PlanType = "Strata",
                    PlanNo = "ST001",
                    RequestingAuthorityReferenceNo = "REF002",
                    Status = "Pending",
                    Lots = 5
                }
            };

            _mockService.Setup(s => s.GetAllAsync(It.IsAny<string>()))
                       .ReturnsAsync(mockData);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<LandMiscellaneousMasterFile>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
            _mockService.Verify(s => s.GetAllAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetAll_WithSortParameter_CallsServiceWithSortBy()
        {
            // Arrange
            var sortBy = "PlanType";
            var mockData = new List<LandMiscellaneousMasterFile>();
            _mockService.Setup(s => s.GetAllAsync(sortBy))
                       .ReturnsAsync(mockData);

            // Act
            var result = await _controller.GetAll(sortBy);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            _mockService.Verify(s => s.GetAllAsync(sortBy), Times.Once);
        }

        [Fact]
        public async Task GetAll_WithEmptyList_ReturnsEmptyOkResult()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>();
            _mockService.Setup(s => s.GetAllAsync(It.IsAny<string>()))
                       .ReturnsAsync(mockData);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<LandMiscellaneousMasterFile>>(okResult.Value);
            Assert.Empty(returnValue);
        }

        #endregion

        #region GetPaginated Tests

        [Fact]
        public async Task GetPaginated_ReturnsOkResult_WithPaginatedData()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>
            {
                new LandMiscellaneousMasterFile
                {
                    Id = 1,
                    MasterFileNo = 1001,
                    PlanType = "Subdivision",
                    PlanNo = "SP001",
                    RequestingAuthorityReferenceNo = "REF001",
                    Status = "Active",
                    Lots = 10
                }
            };
            var totalCount = 25;

            _mockService.Setup(s => s.GetPaginatedAsync(1, 10, ""))
                       .ReturnsAsync((mockData, totalCount));

            // Act
            var result = await _controller.GetPaginated(1, 10, "");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = okResult.Value;

            // Use reflection to check the anonymous object properties
            var recordsProperty = returnValue.GetType().GetProperty("Records");
            var totalCountProperty = returnValue.GetType().GetProperty("TotalCount");
            var pageNumberProperty = returnValue.GetType().GetProperty("PageNumber");
            var pageSizeProperty = returnValue.GetType().GetProperty("PageSize");
            var totalPagesProperty = returnValue.GetType().GetProperty("TotalPages");
            var sortByProperty = returnValue.GetType().GetProperty("SortBy");

            Assert.Equal(mockData, recordsProperty.GetValue(returnValue));
            Assert.Equal(25, totalCountProperty.GetValue(returnValue));
            Assert.Equal(1, pageNumberProperty.GetValue(returnValue));
            Assert.Equal(10, pageSizeProperty.GetValue(returnValue));
            Assert.Equal(3, totalPagesProperty.GetValue(returnValue)); // Math.Ceiling(25/10) = 3
            Assert.Equal("", sortByProperty.GetValue(returnValue));
        }

        [Fact]
        public async Task GetPaginated_WithInvalidPageNumber_UsesDefaultPageNumber()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>();
            _mockService.Setup(s => s.GetPaginatedAsync(1, 10, ""))
                       .ReturnsAsync((mockData, 0));

            // Act
            var result = await _controller.GetPaginated(0, 10, ""); // Invalid page number

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = okResult.Value;
            var pageNumberProperty = returnValue.GetType().GetProperty("PageNumber");

            Assert.Equal(1, pageNumberProperty.GetValue(returnValue)); // Should default to 1
            _mockService.Verify(s => s.GetPaginatedAsync(1, 10, ""), Times.Once);
        }

        [Fact]
        public async Task GetPaginated_WithInvalidPageSize_UsesDefaultPageSize()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>();
            _mockService.Setup(s => s.GetPaginatedAsync(1, 10, ""))
                       .ReturnsAsync((mockData, 0));

            // Act
            var result = await _controller.GetPaginated(1, 0, ""); // Invalid page size

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = okResult.Value;
            var pageSizeProperty = returnValue.GetType().GetProperty("PageSize");

            Assert.Equal(10, pageSizeProperty.GetValue(returnValue)); // Should default to 10
            _mockService.Verify(s => s.GetPaginatedAsync(1, 10, ""), Times.Once);
        }

        [Fact]
        public async Task GetPaginated_WithSortParameter_CallsServiceWithCorrectParameters()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>();
            var sortBy = "PlanType";
            _mockService.Setup(s => s.GetPaginatedAsync(2, 5, sortBy))
                       .ReturnsAsync((mockData, 0));

            // Act
            var result = await _controller.GetPaginated(2, 5, sortBy);

            // Assert
            _mockService.Verify(s => s.GetPaginatedAsync(2, 5, sortBy), Times.Once);
        }

        [Fact]
        public async Task GetPaginated_CalculatesTotalPagesCorrectly()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>();
            var totalCount = 23;
            _mockService.Setup(s => s.GetPaginatedAsync(1, 10, ""))
                       .ReturnsAsync((mockData, totalCount));

            // Act
            var result = await _controller.GetPaginated(1, 10, "");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = okResult.Value;
            var totalPagesProperty = returnValue.GetType().GetProperty("TotalPages");

            Assert.Equal(3, totalPagesProperty.GetValue(returnValue)); // Math.Ceiling(23/10) = 3
        }

        #endregion

        #region Search Tests

        [Fact]
        public async Task Search_ReturnsOkResult_WithSearchResults()
        {
            // Arrange
            var searchTerm = "Subdivision";
            var mockData = new List<LandMiscellaneousMasterFile>
            {
                new LandMiscellaneousMasterFile
                {
                    Id = 1,
                    MasterFileNo = 1001,
                    PlanType = "Subdivision",
                    PlanNo = "SP001",
                    RequestingAuthorityReferenceNo = "REF001",
                    Status = "Active",
                    Lots = 10
                }
            };
            var totalCount = 1;

            _mockService.Setup(s => s.SearchAsync(searchTerm, 1, 10, ""))
                       .ReturnsAsync((mockData, totalCount));

            // Act
            var result = await _controller.Search(searchTerm, 1, 10, "");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = okResult.Value;

            var recordsProperty = returnValue.GetType().GetProperty("Records");
            var totalCountProperty = returnValue.GetType().GetProperty("TotalCount");
            var searchTermProperty = returnValue.GetType().GetProperty("SearchTerm");

            Assert.Equal(mockData, recordsProperty.GetValue(returnValue));
            Assert.Equal(1, totalCountProperty.GetValue(returnValue));
            Assert.Equal(searchTerm, searchTermProperty.GetValue(returnValue));
        }

        [Fact]
        public async Task Search_WithEmptySearchTerm_ReturnsResults()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>();
            _mockService.Setup(s => s.SearchAsync("", 1, 10, ""))
                       .ReturnsAsync((mockData, 0));

            // Act
            var result = await _controller.Search("", 1, 10, "");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            _mockService.Verify(s => s.SearchAsync("", 1, 10, ""), Times.Once);
        }

        [Fact]
        public async Task Search_WithNullResults_ReturnsEmptyList()
        {
            // Arrange
            var searchTerm = "NonExistent";
            List<LandMiscellaneousMasterFile> nullData = null;
            _mockService.Setup(s => s.SearchAsync(searchTerm, 1, 10, ""))
                       .ReturnsAsync((nullData, 0));

            // Act
            var result = await _controller.Search(searchTerm, 1, 10, "");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = okResult.Value;
            var recordsProperty = returnValue.GetType().GetProperty("Records");
            var records = recordsProperty.GetValue(returnValue) as IEnumerable<LandMiscellaneousMasterFile>;

            Assert.NotNull(records);
            Assert.Empty(records);
        }

        [Fact]
        public async Task Search_WithInvalidPagination_UsesDefaults()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>();
            _mockService.Setup(s => s.SearchAsync("test", 1, 10, ""))
                       .ReturnsAsync((mockData, 0));

            // Act
            var result = await _controller.Search("test", 0, 0, ""); // Invalid pagination

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = okResult.Value;
            var pageNumberProperty = returnValue.GetType().GetProperty("PageNumber");
            var pageSizeProperty = returnValue.GetType().GetProperty("PageSize");

            Assert.Equal(1, pageNumberProperty.GetValue(returnValue)); // Should default to 1
            Assert.Equal(10, pageSizeProperty.GetValue(returnValue)); // Should default to 10
            _mockService.Verify(s => s.SearchAsync("test", 1, 10, ""), Times.Once);
        }

        [Fact]
        public async Task Search_WithSortParameter_CallsServiceWithCorrectParameters()
        {
            // Arrange
            var searchTerm = "test";
            var sortBy = "PlanType";
            var mockData = new List<LandMiscellaneousMasterFile>();
            _mockService.Setup(s => s.SearchAsync(searchTerm, 2, 5, sortBy))
                       .ReturnsAsync((mockData, 0));

            // Act
            var result = await _controller.Search(searchTerm, 2, 5, sortBy);

            // Assert
            _mockService.Verify(s => s.SearchAsync(searchTerm, 2, 5, sortBy), Times.Once);
        }

        [Fact]
        public async Task Search_ReturnsAllRequiredProperties()
        {
            // Arrange
            var searchTerm = "test";
            var sortBy = "PlanType";
            var mockData = new List<LandMiscellaneousMasterFile>();
            _mockService.Setup(s => s.SearchAsync(searchTerm, 1, 10, sortBy))
                       .ReturnsAsync((mockData, 0));

            // Act
            var result = await _controller.Search(searchTerm, 1, 10, sortBy);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = okResult.Value;
            var properties = returnValue.GetType().GetProperties();

            Assert.Contains(properties, p => p.Name == "Records");
            Assert.Contains(properties, p => p.Name == "TotalCount");
            Assert.Contains(properties, p => p.Name == "PageNumber");
            Assert.Contains(properties, p => p.Name == "PageSize");
            Assert.Contains(properties, p => p.Name == "TotalPages");
            Assert.Contains(properties, p => p.Name == "SearchTerm");
            Assert.Contains(properties, p => p.Name == "SortBy");
        }

        #endregion

        #region Service Call Verification Tests

        [Fact]
        public async Task GetAll_CallsServiceOnce()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>();
            _mockService.Setup(s => s.GetAllAsync(It.IsAny<string>()))
                       .ReturnsAsync(mockData);

            // Act
            await _controller.GetAll();

            // Assert
            _mockService.Verify(s => s.GetAllAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetPaginated_CallsServiceOnce()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>();
            _mockService.Setup(s => s.GetPaginatedAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                       .ReturnsAsync((mockData, 0));

            // Act
            await _controller.GetPaginated();

            // Assert
            _mockService.Verify(s => s.GetPaginatedAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task Search_CallsServiceOnce()
        {
            // Arrange
            var mockData = new List<LandMiscellaneousMasterFile>();
            _mockService.Setup(s => s.SearchAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                       .ReturnsAsync((mockData, 0));

            // Act
            await _controller.Search();

            // Assert
            _mockService.Verify(s => s.SearchAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        #endregion
    }
}
