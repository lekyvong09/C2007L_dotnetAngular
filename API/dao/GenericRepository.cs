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

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            /**
             * Attach method tracks the entity in the context and change its state to Unchanged
             * When a property is modified after that, the tracking changes will change its state to Modified.
             */
            _context.Set<T>().Attach(entity);

            /**
             * When we have an entity that we know already exists in the database but the changes have already been made then
             * then we need to change the entitystate to Modified explicitly
             * In this case, we don't want to miss any already changes, so we explicitly set entityState as Modified
             */
            _context.Entry(entity).State = EntityState.Modified;

            /**
             * Update will perform update if there is generated key, and will perform add if there is no generated key
             * We don't want to mix up Add() and Update() so we specifically set EntityState.Modified.
             */
            //_context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}