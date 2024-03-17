
namespace e_shop.Brokers.Loggings
{
    internal class LoggingBroker : ILoggingBroker
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void LogError(Exception exception)
        {
            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.WriteLine(exception);
            Console.ResetColor();
        }

        public void LogInformation(string message)
        {
            Console.WriteLine(message);
        }

        public void LogSuccessUser(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
