using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NetCoreFramework.Domain.Specifications.Interface
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecExpression { get; }
    }
}
