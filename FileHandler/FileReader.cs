using simpleIO.Data;

namespace simpleIO.FileHandler;

public class FileReader : IFileReader
{
    private bool _loaded = false;
    private List<ProgramFile> _files = new();

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
            if (!_loaded) CreateFiles();
            for(int i = 0; i < _files.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_files[i].Title}");
            }

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

    private void CreateFiles()
    {
        string path = FileConstants.DIRECTORY_PATH;
        string[] allFiles = Directory.GetFiles(path);
        foreach(string item in allFiles)
        {
            string[] fileData = File.ReadAllLines(item);
            string[] contents = new string[fileData.Length - 1];
            for(int i = 1; i < contents.Length; i++)
            {
                contents[i] = fileData[i];
            }
            ProgramFile file = new ProgramFile(fileData[0], fileData[0] + ".txt", contents);
            _files.Add(file);
        }
        _loaded = true;
    }
}