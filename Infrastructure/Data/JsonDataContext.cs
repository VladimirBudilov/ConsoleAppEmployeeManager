using JsonFlatFileDataStore;

namespace Infrastructure.Data;

public class JsonDataContext
{
    public DataStore store = new DataStore("G:\\CsharpProjects\\Emp\\Infrastructure\\Data\\DataStore.json");
}