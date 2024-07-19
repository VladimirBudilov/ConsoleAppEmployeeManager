using JsonFlatFileDataStore;

namespace Infrastructure.Data;

public class JsonDataContext
{
    public readonly DataStore Store;
    
    public JsonDataContext()
    {
        var path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data");
        Store = new DataStore(path+"\\EmployeeDB.json");
    }
}