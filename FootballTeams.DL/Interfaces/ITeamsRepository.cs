﻿using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Interfaces
{
    public interface ITeamsRepository
    {
        List<Teams> GetTeamByPlacement(int placement);
    }
}
