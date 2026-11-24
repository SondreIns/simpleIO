using simpleIO.Data;

namespace simpleIO.FileHandler;

public class FileWriter : IFileWriter
{

    public void Write(ProgramFile file)
    {
        string path = FileConstants.DIRECTORY_PATH;
        if(!Directory.Exists(path)) Directory.CreateDirectory(path);

        string[][] fileAsString = ConvertFileContents(file);
        string fullPath = Path.Combine(path, fileAsString[0][1]);
        List<string> contents = [fileAsString[0][0]];
        foreach(string item in fileAsString[1]) contents.Add(item);

        File.WriteAllLines(fullPath, contents);
        
    }

    public string[][] ConvertFileContents(ProgramFile file)
    {
        return [[file.Title, file.FileName], file.Items];
    }
}