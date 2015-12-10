using Microsoft.Owin.Hosting;
using System;

namespace testkatana
{
    class Program
    {
        static void Main(string[] args)
        {
            new Bootstrap().InstallDatabase();
            WebApp.Start<Startup>("http://localhost:8080");
            Console.WriteLine("Server Started; Press enter to Quit");
            Console.ReadLine();
            new Bootstrap().UninstallDatabase();
        }
    }
}
