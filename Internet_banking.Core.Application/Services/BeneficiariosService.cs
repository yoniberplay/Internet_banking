using AutoMapper;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Application.ViewModels.Beneficiarios;
using Internet_banking.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Services
{
    public class BeneficiariosService : GenericService<SaveBeneficiarioViewModel, BeneficiariosViewModel, Beneficiarios>
    {
        private readonly IBeneficiariosRepository _beneficiarios;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly AuthenticationResponse userViewModel;
        private readonly IMapper _mapper;

        public BeneficiariosService(IBeneficiariosRepository beneficiarios, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(beneficiarios, mapper)
        {
            _beneficiarios = beneficiarios;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            //userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
        public override async Task<SaveBeneficiarioViewModel> Add(SaveBeneficiarioViewModel data)
        {
            try
            {
                return await base.Add(data);
            }
            catch (Exception ex)
            {
                return BadRequestObjectResult(ex.Message);
            }
        }

        public async Task<List<BeneficiariosViewModel>> GetAllWithIncludeAsync()
        {
            var beneficiarios = await _beneficiarios.GetAllAsync();

            return beneficiarios.Select(data => new BeneficiariosViewModel
            {
                Id = data.Id,
                NombreBeneficiario = data.NombreBeneficiario,
                ApellidoBeneficiarios = data.ApellidoBeneficiarios,
                NumeroCuenta = data.NumeroCuenta
            }).ToList();
        }
        public async Task<List<BeneficiariosViewModel>> GetBeneficiaryByAccountNumber(int accountNumber)
        {
            var beneficiarios = await _beneficiarios.GetAllAsync();

            if(accountNumber != null)
            {
                beneficiarios = beneficiarios.Where(data => data.NumeroCuenta == accountNumber).ToList();
            }

            return beneficiarios.Select(data => new BeneficiariosViewModel
            {
                Id = data.Id,
                NombreBeneficiario = data.NombreBeneficiario,
                ApellidoBeneficiarios = data.ApellidoBeneficiarios,
                NumeroCuenta = data.NumeroCuenta
            }).ToList();
        }

        private SaveBeneficiarioViewModel BadRequestObjectResult(string message)
        {
            throw new NotImplementedException();
        }
    }
}
