﻿using Medication_Order_Service.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly MedicationOrderServiceDbContext _context = null;
        private DbSet<TEntity> table = null;

        public GenericRepository()
        {
            this._context = new MedicationOrderServiceDbContext();
            table = _context.Set<TEntity>();
        }

        public GenericRepository(MedicationOrderServiceDbContext context)
        {
            this._context = context;
            table = _context.Set<TEntity>();
        }

        public async Task Detach(TEntity entity)
        {
            var entry = await Task.Run(() => _context.Entry(entity));
            if (entry.State == EntityState.Detached)
            {
                return;
            }

            entry.State = EntityState.Detached;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            // Kiểm tra xem thực thể đã được theo dõi chưa
            var local = await Task.Run(() => _context.Set<TEntity>().Local.FirstOrDefault(e => e == entity));
            if (local != null)
            {
                // Nếu thực thể đã được theo dõi, gỡ bỏ nó
                _context.Entry(local).State = EntityState.Detached;
            }

            // Đính kèm thực thể và đánh dấu nó để xóa
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable().AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetByWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsNoTracking();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var local = await Task.Run(() => _context.Set<TEntity>().Local.FirstOrDefault(e => e == entity));
            if (local != null)
            {
                // Nếu thực thể đã được theo dõi, gỡ bỏ nó
                _context.Entry(local).State = EntityState.Detached;
            }

            // Đính kèm thực thể và đánh dấu nó để cập nhật
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<TEntity>().CountAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (pageNumber == 0) pageNumber = 1;
            if (pageSize == 0) pageSize = 10;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize)
                              .AsNoTracking()
                              .ToListAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _context.Set<TEntity>().RemoveRange(entities));
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _context.Set<TEntity>().UpdateRange(entities));
        }
    }
}

