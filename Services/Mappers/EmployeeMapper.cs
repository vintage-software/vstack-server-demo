using Domain;
using Services.Persistence;
using Vstack.Services.Mappers;

namespace Services.Mappers
{
    public class EmployeeMapper : BaseEfAndStoredProcMapper<DbContext, Employee>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Ussually we'd use DI")]
        public EmployeeMapper()
            : base(new DbContext())
        {
        }
    }
}
