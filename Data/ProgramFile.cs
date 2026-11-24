namespace simpleIO.Data;

public class ProgramFile
{
    public string Title { get; private set; }
    public string FileName { get; }
    public string[] Items { get; private set; }

    public ProgramFile(string title, string fileName, string[] items)
    {
        Title = title;
        FileName = fileName;
        Items = items;
    }
}