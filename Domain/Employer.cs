using System.Collections.Generic;
using Vstack.Services.Domain;

namespace Domain
{
    public class Employer : BaseDomain
    {
        public Employer(string name)
        {
            this.Name = name;
        }

        private Employer()
        {
        }

        public ICollection<Employee> Employees { get; private set; }

        public string Name { get; private set; }
    }
}