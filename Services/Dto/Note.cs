using Vstack.Services.Dto;

namespace Services.Dto
{
    public class Note : SecureDto, IRestDto
    {
        public int Id { get; set; }

        public int NotebookId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Notebook Notebook { get; set; }
    }
}
