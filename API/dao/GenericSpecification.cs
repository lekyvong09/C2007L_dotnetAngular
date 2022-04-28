using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.dao
{
    public class GenericSpecification<T> : IGenericSpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Criteria {get; set;}
        public List<Expression<Func<T, object>>> Includes {get; set;} = new List<Expression<Func<T, object>>>();

        public GenericSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        /// add Include Expression into List of Expression
        protected void AddIncludes(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}