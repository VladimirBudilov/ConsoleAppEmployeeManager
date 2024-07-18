namespace Infrastructure.Data;

public class JsonDataContext
{
    private readonly string _filePath;

    public JsonDataContext(string filePath)
    {
        _filePath = filePath;
    }

    // Методы для чтения и записи данных в JSON файл
}