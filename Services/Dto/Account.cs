using Vstack.Services.Dto;

namespace Services.Dto
{
    public class Account : SecureDto, IRestDto
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
