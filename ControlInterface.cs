using simpleIO.FileHandler;
using ConsoleHelper;

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
                    keepRunning = true;
                    break;
                case 2:
                    Console.WriteLine("Open existing file selected");
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
}