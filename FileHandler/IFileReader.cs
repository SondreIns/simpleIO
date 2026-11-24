namespace simpleIO.FileHandler;

public interface IFileReader
{
    void Read(string fileName);
    void LoadAllFilenames();
    bool CheckIfFileExists(string fileName);
}