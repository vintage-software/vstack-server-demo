using Vstack.Services.Dto;

namespace Services.EF.Dto
{
    public class Employer : SecureDto, IRestDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Employee[] Employees { get; set; }
    }
}
