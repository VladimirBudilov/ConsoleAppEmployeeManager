using MediatR;

namespace Presentation.Commands;

public class AddEmployee(IMediator mediator) : IExecutable
{
    public Task Execute(string[] args)
    {
        throw new NotImplementedException();
    }
}