using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace API.dao
{
    public interface IGenericSpecification<T> where T : class
    {
        // keep Where criteria
        Expression<Func<T, bool>> Criteria {get; set;}

        List<Expression<Func<T, object>>> Includes {get; set;}

        /// to sort price column (order by)
        Expression<Func<T, object>> OrderBy { get; set; }
        Expression<Func<T, object>> OrderByDesc { get; set; }
    }
}