using Castle.Core.Logging;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using Moq;
using FootballTeams.BL.Services;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.DTO;
using FootballTeams.BL.Interfaces;

namespace FootballTeams.Tests
{
    public class TeamServiceTests
    {
        private readonly Mock<ITeamsRepository> _teamRepositoryMock;
        private readonly Mock<IPlayerRepository> _playerRepositoryMock;

        private List<Players> _players = new List<Players>
        {
            new Players()
            {
                Id = "1",
                Name = "Dimitar Petkov"
            },
            new Players()
            {
                Id = "2",
                Name = "Martin Kamburov"
            },
            new Players()
            {
                Id = "3",
                Name = "Georgi Iliev"
            }
        };

        private List<Teams> _teams = new List<Teams>()
        {
            new Teams()
            {
                Id = "1",
                Name = "Lokomotiv Plovdiv",
                Ranking = 1
            },
            new Teams()
            {
                Id = "2",
                Name = "Botev Plovdiv",
                Ranking = 2
            },
            new Teams()
            {
                Id = "3",
                Name = "CSKA-Sofia",
                Ranking = 3
            }
        };
        public TeamServiceTests()
        {
            _teamRepositoryMock = new Mock<ITeamsRepository>();
            _playerRepositoryMock = new Mock<IPlayerRepository>();
        }

        [Fact]
        void GetById_Ok()
        {
            //Arrange
            var teamId = _teams[0].Id;

            _teamRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((string id) => _teams.FirstOrDefault(m => m.Id == id));

            
            var loggerMock = new Mock<ILogger<TeamsService>>();
            ILogger<TeamsService> logger = loggerMock.Object;

            //Act
            var teamService = new TeamsService(
                _teamRepositoryMock.Object,
                logger,
                _playerRepositoryMock.Object);

            var result = teamService.GetById(teamId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(teamId, result.Id);
        }

        [Fact]
        void GetById_NotExistingId()
        {
            //Arrange
            var teamId = Guid.NewGuid().ToString();

            _teamRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((string id) => _teams.FirstOrDefault(m => m.Id == id));

            var loggerMock = new Mock<ILogger<TeamsService>>();
            ILogger<TeamsService> logger = loggerMock.Object;

            //Act
            var teamService = new TeamsService(
                _teamRepositoryMock.Object,
                logger,
                _playerRepositoryMock.Object);

            var result = teamService.GetById(teamId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        void GetById_WrongGuidId()
        {
            //Arrange
            var teamId = "gnuasd";

            _teamRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((string id) => _teams.FirstOrDefault(m => m.Id == id));

            var loggerMock = new Mock<ILogger<TeamsService>>();
            ILogger<TeamsService> logger = loggerMock.Object;

            //Act
            var teamService = new TeamsService(
                _teamRepositoryMock.Object,
                logger,
                _playerRepositoryMock.Object);

            var result = teamService.GetById(teamId);

            //Assert
            Assert.Null(result);
        }
    }
}
