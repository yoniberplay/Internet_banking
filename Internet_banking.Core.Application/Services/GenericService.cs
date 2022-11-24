using AutoMapper;
using Internet_banking.Core.Application.Dtos.Email;
using Internet_banking.Core.Application.Helpers;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Application.Interfaces.Services;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Internet_banking.Core.Application.Services
{
    public class GenericService<SaveViewmodel, ViewModel,Entity> : IGenericService<SaveViewmodel,ViewModel, Entity>
        where SaveViewmodel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        
        public virtual async Task Update(SaveViewmodel vm,int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);

            await _repository.UpdateAsync(entity,id);
        }

        public virtual async Task<SaveViewmodel> Add(SaveViewmodel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            entity = await _repository.AddAsync(entity);
            SaveViewmodel svm = _mapper.Map<SaveViewmodel>(entity);

            return svm;
        }

        public virtual async Task Delete(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task<SaveViewmodel> GetByIdSaveViewModel(int id)
        {
            Entity user = await _repository.GetByIdAsync(id);

            SaveViewmodel vm = _mapper.Map<SaveViewmodel>(user);


            return vm;

        }



        public virtual async Task<List<ViewModel>> GetAllViewModel()
        {
            var userList = await _repository.GetAllAsync();

            return _mapper.Map<List<ViewModel>>(userList);

        }

        public virtual async Task<ViewModel> GetByIdViewModel(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            return _mapper.Map<ViewModel>(user);

        }

    }
}
