using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.dao
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        /// inject Where() and Include() into IQuery
        Task<T> GetEntityWithSpec(IGenericSpecification<T> specification);
        Task<List<T>> GetEntityListWithSpec(IGenericSpecification<T> specification);
    }
}