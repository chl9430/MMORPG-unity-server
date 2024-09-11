namespace ServerApplication
{
    class Program
    {
        private static Thread threadConsole;
        private static bool consoleRunning;

        static void Main()
        {
            threadConsole = new Thread(new ThreadStart(ConsoleThread));
            threadConsole.Start();
            Network.instance.ServerStart();
        }

        private static void ConsoleThread()
        {
            string line;
            consoleRunning = true;

            while (consoleRunning)
            {
                line = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(line))
                {
                    consoleRunning = false;
                    return;
                }
                else
                {

                }
            }
        }
    }
}