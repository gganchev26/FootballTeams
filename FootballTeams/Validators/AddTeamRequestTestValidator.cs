using FluentValidation;
using FootballTeams.Controllers;
using FootballTeams.Models.Requests;

namespace FootballTeams.Validators
{
    public class AddTeamRequestTestValidator : AbstractValidator<Models.Requests.AddTeamRequest>
    {
        public AddTeamRequestTestValidator() {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .MinimumLength(2);

            RuleFor(x => x.Placement)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.AfterDate)
                .NotNull()
                .NotEmpty();
        }
    }
}
