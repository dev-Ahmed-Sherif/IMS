using AutoMapper;
using DAL;
using DAL.Migrations;
using Entities;
using Entities.ExtensionMethods;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class GenericService<T>
        where T : EntityBase
    {
        protected readonly GenericRepository<T> _repository;
        protected readonly UnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public GenericService(
            GenericRepository<T> repository,
            UnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        virtual public async Task<int> Add(T model)
        {
            _repository.Add(model);
            return await _unitOfWork.SaveChangesAsync();
        }
        virtual public async Task<int> Update(T model)
        {
            _repository.Update(model);
            return await _unitOfWork.SaveChangesAsync();
        }
        virtual public async Task<int> SoftDelete(T model)
        {
            _repository.SoftDelete(model);
            return await _unitOfWork.SaveChangesAsync();
        }
        virtual public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        virtual public IQueryable<T> GetPaginated(PaginationInputViewModel pagination)
        {
            return _repository.GetAll().ToPaginatedResultUnMapped(pagination);
        }
        virtual public IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            return _repository.GetAll(predicate);
        }
    }
}
