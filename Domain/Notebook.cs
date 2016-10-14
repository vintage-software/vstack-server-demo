using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vstack.Services.Domain;

namespace Domain
{
    public class Notebook : BaseDomain
    {
        public Notebook(string title, string description, int accountId)
        {
            this.Title = title;
            this.Description = description;
            this.AccountId = accountId;
        }

        private Notebook()
        {
        }

        public string Title { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }

        public virtual IEnumerable<Note> Notes { get; set; }
    }
}