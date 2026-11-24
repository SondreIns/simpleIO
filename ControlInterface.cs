using simpleIO.FileHandler;
using ConsoleHelper;
using simpleIO.Data;

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

    public bool Run()
    {
        bool keepRunning = true;
        ConsoleWriter.WriteLine("Select an option:", ConsoleColor.Green);
        Console.WriteLine("1. New file");
        Console.WriteLine("2. Open existing file");
        Console.WriteLine("3. Quit");

        string? result = Console.ReadLine();
        if(int.TryParse(result, out int choice))
        {
            switch(choice)
            {
                case 1:
                    Console.WriteLine("New file selected");
                    WriteFile();
                    keepRunning = true;
                    break;
                case 2:
                    Console.WriteLine("Open existing file selected");
                    _reader.LoadAllFilenames();
                    keepRunning = true;
                    break;
                case 3:
                    Console.WriteLine("Quit selected");
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    keepRunning = true;
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
        }

        return keepRunning;
    }


    private void WriteFile(string fileTitle)
    {
        
    }

    private void WriteFile()
    {
        ConsoleWriter.Write("Enter title: ", ConsoleColor.Cyan);
        string? input = Console.ReadLine();
        Console.WriteLine();
        if(string.IsNullOrWhiteSpace(input))
        {
            ConsoleWriter.WriteLine("Error - file name must not be empty", ConsoleColor.Red);
            return;
        }

        string fileName = input + ".txt";
        if(_reader.CheckIfFileExists(fileName))
        {
            ConsoleWriter.WriteLine("Error - file with that name already exists", ConsoleColor.Red);
            return;
        }
        ProgramFile file = new ProgramFile(input, fileName, ["test", "boiga boiga"]);
        _writer.Write(file);
    }   
}