using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel,Entity>
           where SaveViewModel : class
           where ViewModel : class
           where Entity : class
    {
        Task Update(SaveViewModel vm,int id);

        Task<SaveViewModel> Add(SaveViewModel vm);

        Task Delete(int id);

        Task<SaveViewModel> GetByIdSaveViewModel(int id);

        Task<List<ViewModel>> GetAllViewModel();
    }

}
