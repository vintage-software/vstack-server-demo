using Domain;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Vstack.Services.Filters;

namespace Services.Filters
{
    public class ByName : EntityEqualityStoredProcedurePrimaryFilter<Employee, EmployeeMapper>, IPrimaryFilter<Employee, EmployeeMapper>
    {
        private readonly string name;

        public ByName(string name)
        {
            this.name = name;
        }

        public override IEnumerable<Expression<Func<Employee, object>>> Expressions
        {
            get
            {
                return new Expression<Func<Employee, object>>[]
                {
                    i => i.Name
                };
            }
        }

        public override object[] GetParameters()
        {
            return new object[] { this.name };
        }
    }
}
