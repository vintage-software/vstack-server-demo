using System.ComponentModel.DataAnnotations.Schema;
using Vstack.Services.Domain;

namespace Domain
{
    public class Note : BaseDomain
    {
        public Note(string title, string body, int notebookId)
        {
            this.Title = title;
            this.Body = body;
            this.NotebookId = notebookId;
        }

        private Note()
        {
        }

        public string Title { get; set; }

        public string Body { get; set; }

        [ForeignKey(nameof(Notebook))]
        public int NotebookId { get; set; }

        public virtual Notebook Notebook { get; set; }
    }
}