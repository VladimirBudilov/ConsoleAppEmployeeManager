using Application.Commands;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Presentation.Utilities;
using Presentation.Utilities.Validators;

namespace Presentation.Commands;

public class DeleteEmployee(
    IMediator mediator,
    IdParser parser,
    ArgsCountValidator argsCountValidator,
    IValidator<int> argsValidator) : IExecutable
{
    public async Task Execute(string[] args)
    {
        if (!argsCountValidator.Validate(args, 2)) return;
        var id = parser.ParseId(args);
        var validationResult = await argsValidator.ValidateAsync(id);
        if (!validationResult.IsValid)
        {
            WriteLineHelper.ShowErrors(validationResult);
            return;
        }

        var command = new DeleteEmployeeCommand(id);
        var result = await mediator.Send(command);
        WriteLineHelper.ShowResult(result);
    }
}