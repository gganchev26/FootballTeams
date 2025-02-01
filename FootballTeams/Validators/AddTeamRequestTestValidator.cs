using FluentValidation;
using FootballTeams.Models.Request;


namespace FootballTeams.Validators
{
    public class AddTeamRequestTestValidator : AbstractValidator<AddTeamRequest>
    {
        public AddTeamRequestTestValidator() {
            RuleFor(x => x.TeamName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .MinimumLength(2);

            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
