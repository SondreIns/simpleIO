using simpleIO.FileHandler;

namespace simpleIO;

class Program
{
    static void Main(string[] args)
    {
        ControlInterface debug = new ControlInterface(new FileReader(), new FileWriter());
        bool run = true;
        while(run) run = debug.Run();
    }
}
