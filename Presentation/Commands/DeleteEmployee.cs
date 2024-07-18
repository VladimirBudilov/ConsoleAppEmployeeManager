using MediatR;

namespace Presentation.Commands;

public class DeleteEmployee(IMediator mediator) : IExecutable
{
    public Task Execute(string[] args)
    {
        throw new NotImplementedException();
    }
}