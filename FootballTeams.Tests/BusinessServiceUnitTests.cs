

using FootballTeams.BL.Interfaces;
using FootballTeams.BL.Services;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.DTO;
using Moq;

namespace FootballTeams.Tests
{
    public class BusinessServiceUnitTests
    {
        private readonly Mock<ITeamService> _teamServiceMock;
        private readonly Mock<IPlayerService> _playerServiceMock;

        public static List<Teams> TeamData = new List<Teams>
        {
            new Teams()
            {
                Id = Guid.NewGuid().ToString(),
                PlayerId = 1,
                TeamName = "Lokomotiv Plovdiv"
            },
            new Teams()
            {
                Id = Guid.NewGuid().ToString(),
                PlayerId = 2,
                TeamName = "Levski Sofia"
            },
            new Teams()
            {
                Id = Guid.NewGuid().ToString(),
                PlayerId = 3,
                TeamName = "CSKA-Sofia"
            },
            new Teams()
            {
                Id = Guid.NewGuid().ToString(),
                PlayerId = 4,
                TeamName = "Botev Plovdiv"
            },
        };

        public static List<Players> _players = new List<Players>
        {
            new Players()
            {
                Id = 1,
                PlayerName = "Mitko",
                Age = 25
            },
            new Players()
            {
                Id = 2,
                PlayerName = "Ivan",
                Age = 25
            },
            new Players()
            {
                Id = 3,
                PlayerName = "Gosho",
                Age = 25
            },
            new Players()
            {
                Id = 4,
                PlayerName = "Dragan",
                Age = 25
            },
        };

        public BusinessServiceUnitTests() 
        { 
            _teamServiceMock = new Mock<ITeamService>();
            _playerServiceMock = new Mock<IPlayerService>();
        }

        [Fact]
        public void TeamCount_OK()
        {
            //setup
            var input = 5;
            var playerId = 1;
            var expectedCount = 5;

            var mockedTeamository = new Mock<ITeamsRepository>();
            var mockedPlayerRepository = new Mock<IPlayerRepository>();

            mockedTeamository.Setup(x => x.GetAllTeamsFromPlayers(playerId)).Returns(TeamData.Where(g => g.PlayerId == playerId).ToList()); 

            //inject
            var teamService = new TeamsService(mockedTeamository.Object);
            var playerService = new PlayerService(mockedPlayerRepository.Object);
            var businessService = new BusinessService(
                _teamServiceMock.Object,
                _playerServiceMock.Object);

            //act
            var result = businessService.GetAllTeamsCount(input, playerId);

            //Asert
            Assert.Equal(expectedCount, result);

        }
    }
}
