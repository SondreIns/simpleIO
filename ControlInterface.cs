using simpleIO.FileHandler;
using ConsoleHelper;
using simpleIO.Data;

namespace simpleIO;

public class ControlInterface
{
    private IFileReader _reader;
    private IFileWriter _writer;
    private ProgramFile _currentFile;

    public ControlInterface(IFileReader reader, IFileWriter writer)
    {
        _reader = reader;
        _writer = writer;
        _currentFile = new ProgramFile("empty", "empty", []);
    }

    public bool Run()
    {
        Console.Clear();
        bool keepRunning = true;
        ConsoleWriter.WriteLine("Select an option:", ConsoleColor.Green);
        Console.WriteLine("1. New file");
        Console.WriteLine("2. Open existing file");
        Console.WriteLine("3. Quit");

        string? result = Console.ReadLine();
        Console.Clear();
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
                    _reader.ReloadFiles();
                    ConsoleWriter.WriteLine("Select file to open", ConsoleColor.Cyan);
                    if(GetReadInput(_reader.LoadAllFilenames())) ListFileContents();
                    else ConsoleWriter.WriteLine("Error - invalid input", ConsoleColor.Red);
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

    private void ListFileContents()
    {
        ConsoleWriter.WriteLine($"{_currentFile.Title} - from {_currentFile.FileName}:", ConsoleColor.Green);
        foreach(string item in _currentFile.Items) Console.WriteLine(item);
        ConsoleWriter.WriteLine("---------------------------------", ConsoleColor.Yellow);
        Console.ReadKey();
    }

    private bool GetReadInput(int numFiles)
    {
        string? input = Console.ReadLine();
        Console.Clear();
        if(!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int inputInt))
        {
            int choice = inputInt - 1;
            if(choice < 0 || choice >= numFiles) return false;

            _currentFile = _reader.GetFile(choice);
            return true;
        }
        return false;

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

        // REFACTOR THIS vvvvvvvvvvvvvv
        bool isFinished = false;
        List<string> content = new();
        while(!isFinished)
        {
            Console.WriteLine("File open: " + input);
            ConsoleWriter.WriteLine("What do you want to do?", ConsoleColor.Green);
            Console.WriteLine("1. New item");
            Console.WriteLine("2. Save file");
            string? choice = Console.ReadLine();
            if(int.TryParse(choice, out int choiceInt))
            {
                if(choiceInt == 1)
                {
                    ConsoleWriter.WriteLine("Input item:", ConsoleColor.Cyan);
                    string? itemToAdd = Console.ReadLine();
                    if(!string.IsNullOrWhiteSpace(itemToAdd)) content.Add(itemToAdd);
                    ConsoleWriter.WriteLine("Item added!", ConsoleColor.Yellow);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (choiceInt == 2)
                {
                    isFinished = true;
                }
                else
                {
                    ConsoleWriter.WriteLine("Error - invalid choice", ConsoleColor.Red);
                }
            }
            else ConsoleWriter.WriteLine("Error - invalid input", ConsoleColor.Red);
            
        }
        ProgramFile file = new ProgramFile(input, fileName, content.ToArray());
        _writer.Write(file);
        ConsoleWriter.WriteLine("File saved", ConsoleColor.Yellow);
        Console.ReadKey();
    }   
}