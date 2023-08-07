interface IJsonReader: IService
{
    bool JsonExists(string path);
    T Read<T>(string filePath);
    void Write<T>(string filePath, T value);
}