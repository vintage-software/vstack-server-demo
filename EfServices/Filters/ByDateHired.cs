using Domain;
using System;
using System.Linq;
using Vstack.Services.Filters;

namespace Services.EF.Filters
{
    public class ByDateHired : ISecondaryFilter<Employee>
    {
        private readonly DateTime? from;

        private readonly DateTime? to;

        public ByDateHired(DateTime? from, DateTime? to)
        {
            this.from = from;
            this.to = to;
        }

        public IQueryable<Employee> SecondaryFilter(IQueryable<Employee> domains)
        {
            return domains.Where(i =>
                (this.from < i.UtcDateCreated || this.from == null)
                && (i.UtcDateCreated < this.to || this.to == null));
        }
    }
}
