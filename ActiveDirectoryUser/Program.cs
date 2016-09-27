using System;

namespace ActiveDirectoryUser
{
    class Program
    {
        static void Main(string[] args)
        {
            var adService = new ActiveDirectoryService(new Output());

            Console.WriteLine($"Name: {adService.GetName()}");
            Console.WriteLine($"User name: {adService.GetUserName()}");
            Console.WriteLine($"Email: {adService.GetEmailAddress()}");
        }
    }
}