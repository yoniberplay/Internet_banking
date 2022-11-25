//using Internet_banking.Core.Application.ViewModels.Comments;
//using Internet_banking.Core.Application.ViewModels.Post;
//using Internet_banking.Core.Application.ViewModels.Friendship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//added
using Internet_banking.Core.Domain.Entities;
using Internet_banking.Core.Application.Dtos.Account;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Application.ViewModels.Cuenta;
using Internet_banking.Core.Application.ViewModels.Beneficiarios;
using Internet_banking.Core.Application.ViewModels.PagoExpreso;
using AutoMapper;
using Internet_banking.Core.Application.ViewModels.Prestamo;
using Internet_banking.Core.Application.ViewModels.Product;
using Internet_banking.Core.Application.ViewModels.TarjetaCredito;
using Internet_banking.Core.Application.ViewModels.Transaccion;

namespace Internet_banking.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            // User Profiles
            #region UserProfile
            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();
            #endregion

            // Cuenta
            #region Cuenta
            CreateMap<Cuenta, CuentaViewModel>()
                .ReverseMap();

            CreateMap<Cuenta, SaveCuentaViewModel>()
                .ReverseMap()
               .ForMember(dest => dest.Created, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModified, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ForMember(dest => dest.Beneficiario, opt => opt.Ignore());
            #endregion

            // Beneficiarios
            #region Beneficiarios

            CreateMap<Beneficiarios, BeneficiariosViewModel>()
                .ReverseMap();

            CreateMap<Beneficiarios, SaveBeneficiarioViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Productos, opt => opt.Ignore());

            #endregion

            // Pago Expreso
            #region Pagos Expresos

            CreateMap<PagoExpreso, PagoExpresoViewModel>()
                .ReverseMap();

            CreateMap<PagoExpreso, SavePagoExpresoViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Beneficiarios, opt => opt.Ignore());

            #endregion

            // Prestamos
            #region Prestamos

            CreateMap<Prestamo, PrestamoViewModel>()
                .ReverseMap();

            CreateMap<Prestamo, SavePrestamoViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            #endregion

            // Productos
            #region Productos

            CreateMap<Producto, ProductoViewModel>()
                .ReverseMap();

            CreateMap<Producto, SaveProductoViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Beneficiario, opt => opt.Ignore());

            #endregion

            // Tarjeta de Credito
            #region TarjetaCredito
            CreateMap<TarjetaCredito, TarjetaCreditoViewModel>()
                .ReverseMap();

            CreateMap<TarjetaCredito, SaveTarjetaCreditoViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Tipo, opt => opt.Ignore());
            #endregion

            // Transacción
            #region Transacción
            CreateMap<Transacciones, TransaccionViewModel>()
                .ReverseMap();

            CreateMap<Transacciones, SaveTransaccionViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());
            #endregion

            #region NotUsed()
            //#region mapeo de post
            //CreateMap<Post, PostViewModel>()
            //    .ReverseMap()
            //    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            //    .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            //    .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            //CreateMap<Post, SavePostViewModel>()
            //    .ForMember(dest => dest.File, opt => opt.Ignore())
            //    .ForMember(dest => dest.NuevoComentario, opt => opt.Ignore())
            //    .ForMember(dest => dest.Idpost, opt => opt.Ignore())
            //   .ReverseMap()
            //   .ForMember(dest => dest.Created, opt => opt.Ignore())
            //   .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            //   .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            //   .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            //#endregion

            //#region mapeo de comments
            //CreateMap<Comments, CommentsViewModel>()
            //    .ReverseMap()
            //    .ForMember(dest => dest.Created, opt => opt.Ignore())
            //    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            //    .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            //    .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            //CreateMap<Comments, SaveCommentViewModel>()
            //   .ReverseMap()
            //   .ForMember(dest => dest.User, opt => opt.Ignore())
            //   .ForMember(dest => dest.Post, opt => opt.Ignore())
            //   .ForMember(dest => dest.Created, opt => opt.Ignore())
            //   .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            //   .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            //   .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            //#endregion

            //#region mapeo de Amistad
            //CreateMap<Friendship, FriendshipViewModel>()
            //    .ReverseMap()
            //    .ForMember(dest => dest.Created, opt => opt.Ignore())
            //    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            //    .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            //    .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            //CreateMap<Friendship, SaveFriendViewModel>()
            //     .ForMember(dest => dest.amigo, opt => opt.Ignore())
            //   .ReverseMap()
            //   .ForMember(dest => dest.Created, opt => opt.Ignore())
            //   .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            //   .ForMember(dest => dest.LastModified, opt => opt.Ignore())
            //   .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            //#endregion


            #endregion
        }
    }
}
