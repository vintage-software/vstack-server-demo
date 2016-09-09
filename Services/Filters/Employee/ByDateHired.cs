using System;
using System.Linq;
using Vstack.Services.Filters;
using Dmn = Domain;

namespace Services.Filters.Employee
{
    public class ByDateHired : IFilter<Dmn.Employee>
    {
        private readonly DateTime? from;

        private readonly DateTime? to;

        public ByDateHired(DateTime? from, DateTime? to)
        {
            this.from = from;
            this.to = to;
        }

        public IQueryable<Dmn.Employee> Filter(IQueryable<Dmn.Employee> domains)
        {
            return domains.Where(i =>
                (this.from < i.UtcDateCreated || this.from == null)
                && (i.UtcDateCreated < this.to || this.to == null));
        }
    }
}
