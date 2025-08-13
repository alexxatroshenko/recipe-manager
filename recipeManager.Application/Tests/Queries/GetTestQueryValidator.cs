using FluentValidation;
namespace recipeManager.Application.Tests.Queries;

public class GetTestQueryValidator: AbstractValidator<GetTestsQuery>
{
    public GetTestQueryValidator()
    {
        RuleFor(x => x.Count).NotEmpty().WithMessage("Count должен быть больше 0");
    }
}