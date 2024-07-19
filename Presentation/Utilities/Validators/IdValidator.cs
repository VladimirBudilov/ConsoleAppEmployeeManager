using FluentValidation;

public class IdValidator : AbstractValidator<int>
{
    public IdValidator()
    {
        RuleFor(id => id).GreaterThan(0).WithMessage("ID must be greater than 0.");
    }
}