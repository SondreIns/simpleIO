using simpleIO.Data;

namespace simpleIO.FileHandler;

public interface IFileWriter
{
    void Write(ProgramFile file);
    string[][] ConvertFileContents(ProgramFile file);
}