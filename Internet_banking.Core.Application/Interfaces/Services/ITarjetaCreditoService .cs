using Internet_banking.Core.Application.ViewModels.TarjetaCredito;
using Internet_banking.Core.Domain.Entities;

namespace Internet_banking.Core.Application.Interfaces.Services
{
    public interface ITarjetaCreditoService : IGenericService<SaveTarjetaCreditoViewModel, TarjetaCreditoViewModel, TarjetaCredito>
    {
    }
}
