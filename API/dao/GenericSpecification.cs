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
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }

        public GenericSpecification() { }
        public GenericSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        /// add Include Expression into List of Expression
        public void AddIncludes(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        public void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }
    }
}