using Application.Commands;
using Application.Queries;
using FluentValidation;
using MediatR;
using Presentation.Utilities;
using Presentation.Utilities.Validators;

namespace Presentation.Commands;

public class GetEmployee(
    IMediator mediator,
    ArgsParser parser,
    ArgsCountValidator argsCountValidator,
    IValidator<int> argsValidator) : IExecutable
{
    public async Task Execute(string[] args)
    {
        if (!argsCountValidator.Validate(args, 2)) return;
        parser.ParseAndValidateBasic(args, out var id, out _, out _, out _);
        var validationResult = await argsValidator.ValidateAsync(id);
        if (!validationResult.IsValid)
        {
            WriteLineHelper.ShowErrors(validationResult);
            return;
        }

        var command = new GetEmployeeQuery(id);
        var result = await mediator.Send(command);
        WriteLineHelper.ShowResult(result);
    }
}