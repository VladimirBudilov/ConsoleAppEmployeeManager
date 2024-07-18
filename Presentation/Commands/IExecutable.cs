namespace Presentation.Commands;

public interface IExecutable
{
    public Task Execute(string[] args);
}