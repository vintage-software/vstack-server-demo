using System.Collections.Generic;
using Vstack.Services.Converters;

namespace Services.Converters
{
    public class NotebookConverter
        : BaseConverter<Dto.Notebook, Domain.Notebook, General.Permissions>
    {
        protected override Dto.Notebook Convert()
        {
            return new Dto.Notebook()
            {
                Id = this.Domain.Id,
                Title = this.Domain.Title,
                Description = this.Domain.Description,
                AccountId = this.Domain.AccountId,
                Notes = this.GetNotes()
            };
        }

        private IEnumerable<Dto.Note> GetNotes()
        {
            return this.HandlePermissions(
                hasPermissions: true,
                domain: i => i.Notes,
                dto: i => i.Notes,
                converter: new NoteConverter());
        }
    }
}
