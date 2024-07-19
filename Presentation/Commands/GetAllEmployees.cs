using Application.Commands;
using Application.Queries;
using FluentValidation;
using MediatR;
using Presentation.Utilities;
using Presentation.Utilities.Validators;

namespace Presentation.Commands;

public class GetAllEmployees(
    IMediator mediator,
    ArgsCountValidator argsCountValidator) : IExecutable
{
    public async Task Execute(string[] args)
    {
        if (!argsCountValidator.Validate(args, (int)NumberOfArgs.GetAllEmployees)) return;

        var command = new GetEmployeesQuery();
        var result = await mediator.Send(command);
        WriteLineHelper.ShowResult(result);
    }
}