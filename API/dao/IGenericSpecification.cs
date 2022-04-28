using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dao
{
    public interface IGenericSpecification<T>
    {
        // keep Where criteria
        Expression<Func<T, bool>> Criteria {get; set;}

        List<Expression<Func<T, object>>> Includes {get; set;}
    }
}