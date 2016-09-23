using Vstack.Services.Dto;

namespace Services.Dto
{
    public class Notebook : SecureDto, IRestDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AccountId { get; set; }

        public Note[] Notes { get; set; }
    }
}
