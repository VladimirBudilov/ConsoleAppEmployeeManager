// See https://aka.ms/new-console-template for more information
using Presentation.Commands;

try
{
    await RunApplication(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

async Task RunApplication(string[] args)
{
    switch (args[0])
    {
        case "-add":
            await new AddCommand().Execute(args);
            break;
        case "-update":
            await new UpdateCommand().Execute(args);
            break;
        case "-delete":
            await new DeleteCommand().Execute(args);
            break;
        case "-get":
            await new GetCommand().Execute(args);
            break;
        case "-getall":
            await new GetAllCommand().Execute(args);
            break;
        default:
            Console.WriteLine("Unknown command");
            break;
    }
}