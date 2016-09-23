using Vstack.Services.Converters;

namespace Services.Converters
{
    public class NoteConverter
        : BaseConverter<Dto.Note, Domain.Note, General.Permissions>
    {
        protected override Dto.Note Convert()
        {
            return new Dto.Note()
            {
                Id = this.Domain.Id,
                Title = this.Domain.Title,
                Body = this.GetBody(),
                NotebookId = this.Domain.NotebookId
            };
        }

        private string GetBody()
        {
            return this.HandlePermissions(
                hasPermissions: true,
                domain: i => i.Body,
                dto: i => i.Body,
                autoInclude: false);
        }
    }
}
