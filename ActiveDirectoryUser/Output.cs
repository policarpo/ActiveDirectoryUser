using System;

namespace ActiveDirectoryUser
{
    public interface ILog
    {
        void Write(string message);
        void Error(string message, Exception ex);
    }

    public class Output : ILog
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message, Exception ex)
        {
            Console.WriteLine($"{message}{Environment.NewLine}{ex.StackTrace}", ex);
        }
    }
}