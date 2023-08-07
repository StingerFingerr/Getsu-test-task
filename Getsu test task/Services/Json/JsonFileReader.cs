using System.Text.Json;

public class JsonFileReader: IJsonReader
{
    public bool JsonExists(string path) =>
        File.Exists(path);

    public T Read<T>(string filePath)
    {
        string text = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(text);
    }

    public void Write<T>(string filePath, T value)
    {
        string json = JsonSerializer.Serialize(value);
        File.WriteAllText(filePath, json);
    }
}