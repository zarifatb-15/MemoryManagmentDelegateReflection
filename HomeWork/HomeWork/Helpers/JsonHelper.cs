using System.Text.Json;
namespace HomeWork.Helpers;

public static class JsonHelper<T>
{
    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    public static List<T> Read(string path)
    {
        if (!File.Exists(path)) return new List<T>();
        
        string  json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<T>>(json)?? new List<T>();
    }

    public static void Write(string path, List<T> data)
    {
        string json = JsonSerializer.Serialize(data, options);
        File.WriteAllText(path, json);
    }
}