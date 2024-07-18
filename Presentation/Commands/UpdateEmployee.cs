using MediatR;

namespace Presentation.Commands;

public class UpdateEmployee(IMediator mediator) : IExecutable
{
    public Task Execute(string[] args)
    {
        throw new NotImplementedException();
    }
}