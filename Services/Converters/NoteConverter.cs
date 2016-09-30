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
                NotebookId = this.Domain.NotebookId,
                Title = this.Domain.Title,
                Body = this.GetBody(),
                Notebook = this.GetNotebook()
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

        private Dto.Notebook GetNotebook()
        {
            return this.HandlePermissions(
                hasPermissions: true,
                domain: i => i.Notebook,
                dto: i => i.Notebook,
                converter: new NotebookConverter());
        }
    }
}
