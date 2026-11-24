using simpleIO.FileHandler;

namespace simpleIO;

public class ControlInterface
{
    private IFileReader _reader;
    private IFileWriter _writer;

    public ControlInterface(IFileReader reader, IFileWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }
}