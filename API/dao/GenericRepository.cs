using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.dao
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        

        public async Task<T> GetEntityWithSpec(IGenericSpecification<T> specification)
        {
            IQueryable<T> inputQuery = _context.Set<T>().AsQueryable();
            IQueryable<T> outputQuery = GenericSpecificationEvaluator<T>.GetQuery(inputQuery, specification);
            return await outputQuery.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetEntityListWithSpec(IGenericSpecification<T> specification)
        {
            IQueryable<T> inputQuery = _context.Set<T>().AsQueryable();
            IQueryable<T> outputQuery = GenericSpecificationEvaluator<T>.GetQuery(inputQuery, specification);
            return await outputQuery.ToListAsync();
        }

        public async Task<int> CountAsync(IGenericSpecification<T> specification)
        {
            IQueryable<T> inputQuery = _context.Set<T>().AsQueryable();
            IQueryable<T> outputQuery = GenericSpecificationEvaluator<T>.GetQuery(inputQuery, specification);
            return await outputQuery.CountAsync();
        }
    }
}