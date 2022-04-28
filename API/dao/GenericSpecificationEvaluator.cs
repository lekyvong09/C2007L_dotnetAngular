using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dao
{
    public class GenericSpecificationEvaluator<T> where T : class
    {
        /// add Where and Include into Queryable
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IGenericSpecification<T> specification)
        {
            var query = inputQuery;

            if (specification != null)
            {
                query = query.Where(specification.Criteria);
            }
            
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}