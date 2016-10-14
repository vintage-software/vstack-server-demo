using System.Collections.Generic;
using Vstack.Services.Dto;

namespace Services.Dto
{
    public class Notebook : SecureDto, IRestDto
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<Note> Notes { get; set; }
    }
}
