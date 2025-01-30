using Moq;
using FootballTeams.BL.Services;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.DTO;


namespace FootballTeams.Tests
{
    public class BusinessServiceUnitTests
    {
        private readonly Mock<ITeamsRepository> _teamRepositoryMock;
        private readonly Mock<IPlayerRepository> _playerRepositoryMock;

        private List<Players> _players = new List<Players>
        {
            new Players()
            {
                Id = "1",
                Name = "Parviz Umarbaev"
            },
            new Players()
            {
                Id="2",
                Name = "Martin Lukov"
            },
            new Players()
            {
                Id = "3",
                Name = "Julian Lami"
            },
        };

        private List<Teams> _teams = new List<Teams>
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
                Name = "Septemvri Sofia",
                Ranking = 2
            },
            new Teams()
            {
                Id = "3",
                Name = "Maritsa Plovdiv",
                Ranking = 3
            }
        };

        public BusinessServiceUnitTests()
        {
            _teamRepositoryMock = new Mock<ITeamsRepository>();
            _playerRepositoryMock = new Mock<IPlayerRepository>();
        }

        [Fact]
        public void GetAllTeam_Ok()
        {
            //setup
            var expectedCount = 3;

            _teamRepositoryMock.Setup(x => x.GetAll()).Returns(_teams);
            _playerRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((string id) => _players.FirstOrDefault(x => x.Id == id));

            //inject
            var businessService = new BusinessService(
                _teamRepositoryMock.Object,
                _playerRepositoryMock.Object);

            //act
            var result = businessService.GetAllTeams();

            //assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }
    }
}
