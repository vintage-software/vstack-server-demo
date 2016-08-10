using Vstack.Services.Domain;

namespace Domain
{
    public class Employee : BaseDomain
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        private Employee()
        {
        }

        public Employer Employer { get; private set; }

        public string Name { get; private set; }
    }
}