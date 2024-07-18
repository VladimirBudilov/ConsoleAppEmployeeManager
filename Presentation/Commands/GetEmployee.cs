using MediatR;

namespace Presentation.Commands;

public class GetEmployee(IMediator mediator) : IExecutable
{
    public Task Execute(string[] args)
    {
        throw new NotImplementedException();
    }
}