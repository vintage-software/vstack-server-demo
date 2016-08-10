using Domain;
using Services.EF.Persistence;
using Vstack.Services.Mappers;

namespace Services.EF.Mappers
{
    public class EmployeeMapper : BaseEfMapper<DbContext, Employee>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Ussually we'd use DI")]
        public EmployeeMapper()
            : base(new DbContext())
        {
        }
    }
}
