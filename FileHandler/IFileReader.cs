namespace simpleIO.FileHandler;

public interface IFileReader
{
    void Read(string fileName);
    int LoadAllFilenames();
    bool CheckIfFileExists(string fileName);
    void ReloadFiles();
}