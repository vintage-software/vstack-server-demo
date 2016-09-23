using Domain.General;
using System;
using Vstack.Services.Domain;
using Vstack.Services.Security;

namespace Domain
{
    public class Employee : BaseDomain, IVstackBaseUser
    {
        private readonly UserAuthenticationHelper userAuthenticationHelper = new NoteApplicationUserAuthenticationHelper();

        public Employee(int employerId, string emailAddress, string name, string socialSecurityNumber, string password)
        {
            this.EmployerId = employerId;
            this.EmailAddress = emailAddress;
            this.Name = name;
            this.SocialSecurityNumber = socialSecurityNumber;
            this.Password = password;

            this.userAuthenticationHelper.InitializeUser(this);
        }

        private Employee()
        {
        }

        public int EmployerId { get; private set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string Name { get; private set; }

        public string SocialSecurityNumber { get; private set; }

        public decimal AnnualSalary { get; private set; }

        public string InternalNotes { get; private set; }

        public int? InternalNotesSuperUserId { get; private set; }

        public Employer Employer { get; private set; }

        public string SecurityStamp { get; set; }

        public int AccessFailedCount { get; set; }

        public string UniqueKey { get; set; }

        public DateTime? UtcDateLockoutEnds { get; set; }

        public DateTime? UtcDatePasswordLastSet { get; set; }

        public void UpdateInternalNotes(int superUserId, string internalNotes)
        {
            this.InternalNotesSuperUserId = superUserId;
            this.InternalNotes = internalNotes;
        }

        public void UpdateAnnualSalary(decimal annualSalary)
        {
            this.AnnualSalary = annualSalary;
        }

        public void ChangePassword(string password)
        {
            this.Password = password;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }
    }
}