using Domain.General;
using System;
using Vstack.Services.Domain;
using Vstack.Services.Security;

namespace Domain
{
    public class Account : BaseDomain, IVstackBaseUser
    {
        private readonly UserAuthenticationHelper userAuthenticationHelper = new NoteApplicationUserAuthenticationHelper();

        public Account(string emailAddress, string firstName, string lastName, string password)
        {
            this.EmailAddress = emailAddress;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;

            this.userAuthenticationHelper.InitializeUser(this);
        }

        private Account()
        {
        }

        public int AccountId { get; private set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string SecurityStamp { get; set; }

        public int AccessFailedCount { get; set; }

        public string UniqueKey { get; set; }

        public DateTime? UtcDateLockoutEnds { get; set; }

        public DateTime? UtcDatePasswordLastSet { get; set; }

        public void SetPassword(string password)
        {
            this.Password = password;
        }

        public void SetName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}