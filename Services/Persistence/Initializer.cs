using Domain;
using System.Collections.Generic;
using System.Data.Entity;
using Vstack.Extensions;

namespace Services.Persistence
{
    public class Initializer : DropCreateDatabaseIfModelChanges<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            context.ValidateNotNullParameter(nameof(context));

            List<Account> accounts = GetDefaultAccounts();
            List<Notebook> notebooks = new List<Notebook>();
            List<Note> notes = new List<Note>();

            context.Accounts.AddRange(accounts);
            context.SaveChanges();

            // accounts = await context.Accounts.ToListAsync();
            foreach (Account account in accounts)
            {
                notebooks.Add(GetDefaultNotebook(account));
            }

            context.Notebooks.AddRange(notebooks);
            context.SaveChanges();

            // notebooks = await context.Notebooks.ToListAsync();
            foreach (Notebook notebook in notebooks)
            {
                notes.Add(GetDefaultNote(notebook));
            }

            context.Notes.AddRange(notes);
            context.SaveChanges();

            base.Seed(context);
        }

        private static List<Account> GetDefaultAccounts()
        {
            return new List<Account>
            {
                new Account("david@noteapplication.com", "David", "Pfeiffer", "Password123"),
                new Account("steve@noteapplication.com", "Steve", "Haar", "Password123"),
                new Account("kevin@noteapplication.com", "Kevin", "Phelps", "Password123"),
                new Account("hunter@noteapplication.com", "Hunter", "LaTourette", "Password123")
            };
        }

        private static Notebook GetDefaultNotebook(Account account)
        {
            return new Notebook(@"Default Notebook", "For all newly created notes", account.Id);
        }

        private static Note GetDefaultNote(Notebook notebook)
        {
            return new Note("My First Note", "This is your first note. Now go create your own!", notebook.Id);
        }
    }
}
