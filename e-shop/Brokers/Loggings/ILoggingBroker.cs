namespace e_shop.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogError(string message);
        void LogSuccessUser(string message);
        void LogInformation(string message);
        void LogError(Exception exception);
    }
}
