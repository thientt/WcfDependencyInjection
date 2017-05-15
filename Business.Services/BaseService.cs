using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Data.Core.Infrastructure;
using Data.Core.Repositories;

namespace Business.Services
{
    public class BaseService<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseService(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(TEntity blog)
        {
            _repository.Add(blog);
            _unitOfWork.Commit();
        }

        public void Delete(TEntity blog)
        {
            _repository.Delete(blog);
            _unitOfWork.Commit();
        }

        public void Delete(Expression<Func<TEntity, bool>> func)
        {
            _repository.Delete(func);
            _unitOfWork.Commit();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _repository.Get(where);
        }

        // Gets all entities of type T
        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _repository.GetMany(where);
        }

        public int GetKeyId(Func<int> func)
        {
            return _repository.GetKeyId(func);
        }

        public void Update(TEntity blog)
        {
            _repository.Update(blog);
            _unitOfWork.Commit();
        }
    }
}