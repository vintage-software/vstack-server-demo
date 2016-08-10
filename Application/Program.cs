using Domain;
using Services.Filters;
using Services.Services;
using System;
using System.Linq;

namespace Application
{
    public static class Program
    {
        private static readonly EmployeeService Service = new EmployeeService();

        public static void Main()
        {
            Console.WriteLine($"Count: {Service.Get().Count()}");
            Console.WriteLine($"Expression Get: {GetEmployeeByName("Ted")?.Id}");
            Console.WriteLine($"Primary Filter Get: {GetEmployeeByName2("Ted")?.Id}");
            Console.ReadLine();
        }

        private static Employee GetEmployeeByName(string name)
        {
            return Service.Get()
                .Where(i => i.Name == name)
                .FirstOrDefault();
        }

        private static Employee GetEmployeeByName2(string name)
        {
            return Service.Get()
                .WithPrimaryFilter(new ByName(name))
                .FirstOrDefault();
        }
    }
}
