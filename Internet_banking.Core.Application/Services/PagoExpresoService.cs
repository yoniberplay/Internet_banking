using AutoMapper;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Application.ViewModels.Beneficiarios;
using Internet_banking.Core.Application.ViewModels.PagoExpreso;
using Internet_banking.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Services
{
    public class PagoExpresoService : GenericService<SavePagoExpresoViewModelViewModel, PagoExpresoViewModel, PagoExpreso>
    {
        private readonly IPagoExpresoRepository _pagoExpreso;
        private readonly IBeneficiariosRepository _beneficiario;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly AuthenticationResponse userViewModel;
        private readonly IMapper _mapper;

        public PagoExpresoService(IPagoExpresoRepository pagoExpreso, IBeneficiariosRepository beneficiarios, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(pagoExpreso, mapper)
        {
            _pagoExpreso = pagoExpreso;
            _beneficiario = beneficiarios;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            //userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task<SavePagoExpresoViewModelViewModel> PagoExpreso(int numetoCuentaTo, int accountNumber, double CantidadDinero)
        {

            // validate if the beneficiary to transfer already exist

            var beneficiarios = await _beneficiario.GetAllAsync();

            if (accountNumber != null)
            {
                beneficiarios = beneficiarios.Where(data => data.NumeroCuenta == accountNumber).ToList();
            } 

            // transfering proccess

            if (beneficiarios != null)
            {

            }

            return null;
        }
    }
}
