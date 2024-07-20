using FluentValidation;

namespace Presentation.Utilities.Validators;

public class ContentValidator : AbstractValidator<Dictionary<string, string>>
{
    public ContentValidator()
    {
        When(args => args.ContainsKey("FirstName"),
            () => { RuleFor(args => args["FirstName"]).NotEmpty().WithMessage("First name is required."); });

        When(args => args.ContainsKey("LastName"),
            () => { RuleFor(args => args["LastName"]).NotEmpty().WithMessage("Last name is required."); });

        When(args => args.ContainsKey("Salary"),
            () =>
            {
                RuleFor(args => args["Salary"]).Must(BeAValidSalary)
                    .WithMessage("Salary must be a valid decimal number greater than 0.");
            });
    }

    private bool BeAValidSalary(string salary)
    {
        return decimal.TryParse(salary, out var result) && result > 0;
    }
}