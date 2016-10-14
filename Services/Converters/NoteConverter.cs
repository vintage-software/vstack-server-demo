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
                Content = this.GetBody(),
                Notebook = this.GetNotebook()
            };
        }

        private string GetBody()
        {
            return this.HandlePermissions(
                hasPermissions: true,
                domain: i => i.Content,
                dto: i => i.Content,
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
