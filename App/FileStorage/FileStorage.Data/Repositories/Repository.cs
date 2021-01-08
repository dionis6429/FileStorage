using FileStorage.Data.Database;
using FileStorage.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileStorage.Data.Repositories
{
    public sealed class Repository : IRepository
    {
        private readonly FileStorageDbContext _context;
        public Repository(FileStorageDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> From<TEntity>() where TEntity : Entity
        {
            return this._context.Set<TEntity>();

        }

        public TEntity GetById<TEntity>(int id) where TEntity : Entity
        {
            return this._context.Set<TEntity>().Find(id);
        }

        public TEntity Save<TEntity>(TEntity entity) where TEntity : Entity
        { 
            if (entity == null) throw new ArgumentNullException("Entity can not be null.");

            if (entity.IsNew)
            {
                this._context.Set<TEntity>().Add(entity);
            }
            else
            {
                this._context.Entry(entity).State = EntityState.Modified;
            }

            this._context.SaveChanges();
            return entity;
        }

        public void Delete<TEntity>(int entityId) where TEntity : Entity
        {
            var entity = this._context.Set<TEntity>().Find(entityId);
            this._context.Entry(entity).State = EntityState.Deleted;
            this._context.SaveChanges();
        }
    }
}
