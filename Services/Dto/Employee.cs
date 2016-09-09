using Vstack.Services.Dto;

namespace Services.Dto
{
    public class Employee : SecureDto, IRestDto
    {
        public int Id { get; set; }

        public int EmployerId { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string SocialSecurityNumber { get; set; }

        public decimal AnnualSalary { get; set; }

        public string InternalNotes { get; set; }

        public Employer Employer { get; set; }
    }
}
