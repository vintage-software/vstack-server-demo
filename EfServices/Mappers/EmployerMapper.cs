using Domain;
using Services.EF.Persistence;
using Vstack.Services.Mappers;

namespace Services.EF.Mappers
{
    public class EmployerMapper : BaseEfMapper<DbContext, Employer>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Ussually we'd use DI")]
        public EmployerMapper()
            : base(new DbContext())
        {
        }
    }
}
