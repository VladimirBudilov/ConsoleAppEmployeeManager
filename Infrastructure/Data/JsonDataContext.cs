using JsonFlatFileDataStore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data;

public class JsonDataContext
{
    public readonly DataStore Store;
    
    public JsonDataContext()
    {
        var parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
        var databaseDirectory = Path.Combine(parentDirectory, "Database");
        var databasePath = Path.Combine(databaseDirectory, "EmployeeDB.json");
        Store = new DataStore(databasePath);
    }
}