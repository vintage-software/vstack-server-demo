using Domain;
using Services.EF.Filters;
using Services.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Vstack.Services.General;

namespace Application.EF
{
    public static class Program
    {
        private static readonly EmployeeService Service = new EmployeeService();

        public static void Main()
        {
            Console.WriteLine($"Count: {Service.Get().Count()}");
            Console.WriteLine($"Expression Get: {ReadByName("Ted")?.Id}");
            Console.WriteLine($"Primary Filter Get: {SearchForEmployee("Ted", null, null)?.Id}");
            Console.ReadLine();
        }

        private static ActionResult<Employee> Create(string name)
        {
            Employee employee = new Employee(name);
            return Service.Save(employee);
        }

        private static IEnumerable<Employee> ReadAll()
        {
            return Service.Get();
        }

        private static Employee ReadById(int id)
        {
            return Service.Get(id)
                .FirstOrDefault();
        }

        private static Employee ReadByName(string name)
        {
            return Service.Get()
                .Where(i => i.Name == name)
                .FirstOrDefault();
        }

        private static IEnumerable<Employee> ReadManyIncludeEmployer(IEnumerable<int> ids)
        {
            return Service.Get(ids)
                .Include(i => i.Employer);
        }

        private static ActionResult<Employee> Update(Employee employee)
        {
            return Service.Save(employee);
        }

        private static ActionResult<int> Delete(Employee employee)
        {
            return Service.Delete(employee);
        }

        private static Employee SearchForEmployee(string name, DateTime? hiredAfter, DateTime? hiredBefore)
        {
            return Service.Get()
                .Filter(new ByName(name))
                .Filter(new ByDateHired(hiredAfter, hiredBefore))
                .FirstOrDefault();
        }
    }
}
