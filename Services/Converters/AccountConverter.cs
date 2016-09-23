using Vstack.Services.Converters;

namespace Services.Converters
{
    public class AccountConverter
        : BaseConverter<Dto.Account, Domain.Account, General.Permissions>
    {
        protected override Dto.Account Convert()
        {
            return new Dto.Account()
            {
                Id = this.Domain.Id,
                AccountId = this.Domain.AccountId,
                EmailAddress = this.Domain.EmailAddress,
                FirstName = this.Domain.FirstName,
                LastName = this.Domain.LastName,
                Password = this.GetPassword()
            };
        }

        private string GetPassword()
        {
            return this.HandlePermissions(
                hasPermissions: false,
                domain: i => i.Password,
                dto: i => i.Password,
                autoInclude: true);
        }

        //private Dto.Note GetNotes()
        //{
        //    return this.HandlePermissions(
        //        hasPermissions: true,
        //        domain: i => i.Employer,
        //        dto: i => i.Employer,
        //        converter: new EmployerConverter());
        //}
    }
}
