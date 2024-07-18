using MediatR;

namespace Presentation.Commands;

public class GetAllEmployees(IMediator mediator) : IExecutable
{
    public Task Execute(string[] args)
    {
        throw new NotImplementedException();
    }
}
