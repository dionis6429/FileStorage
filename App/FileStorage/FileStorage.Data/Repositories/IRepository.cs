using FileStorage.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileStorage.Data.Repositories
{
    public interface IRepository
    {
        IQueryable<TEntity> From<TEntity>() where TEntity : Entity;

        TEntity GetById<TEntity>(int id) where TEntity : Entity;

        TEntity Save<TEntity>(TEntity entity) where TEntity : Entity;

        void Delete<TEntity>(int entityId) where TEntity : Entity;
    }
}
