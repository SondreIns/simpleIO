namespace simpleIO.FileHandler;

public class FileReader : IFileReader
{
    public void Read(string fileName)
    {
        throw new NotImplementedException();
    }

    public void LoadAllFilenames()
    {
        string path = FileConstants.DIRECTORY_PATH;

        if(!Directory.Exists(path))
        {
            Console.WriteLine("No files found");
        }
        else
        {
            string[] allFiles = Directory.GetFiles(path);
            foreach (string item in allFiles) Console.WriteLine(item);
        }
    }

    public bool CheckIfFileExists(string fileName)
    {
        foreach(string item in Directory.GetFiles(FileConstants.DIRECTORY_PATH))
        {
            if(item.ToUpper() == fileName.ToUpper()) return true;
        }
        return false;
    }
}