using Moq;
using PositionsAPI.Models;
using PositionsAPI.Repositories;
using PositionsAPI.Services;
using Xunit;

namespace PositionsAPI.Tests.Services
{
    public class PositionsServiceTests
    {
        private readonly Mock<IPositionsRepository> _mockRepo;
        private readonly PositionsService _service;

        public PositionsServiceTests()
        {
            _mockRepo = new Mock<IPositionsRepository>();
            _service = new PositionsService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllPositions_ReturnsAllPositions()
        {
            // Arrange
            var positions = new List<Position>
            {
                new Position { PositionId = 1, Title = "Developer" },
                new Position { PositionId = 2, Title = "Manager" }
            };
            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(positions);

            // Act
            var result = await _service.GetAllPositions();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetPositionById_ReturnsPosition_WhenPositionExists()
        {
            // Arrange
            var position = new Position { PositionId = 1, Title = "Developer" };
            _mockRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(position);

            // Act
            var result = await _service.GetPositionById(1);

            // Assert
            Assert.Equal("Developer", result.Title);
        }

        [Fact]
        public async Task CreatePosition_ThrowsException_WhenRequiredFieldsMissing()
        {
            // Arrange
            var position = new Position { Title = "" }; // Missing required fields

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.CreatePosition(position));
        }

        // Add more tests for other scenarios
    }
}