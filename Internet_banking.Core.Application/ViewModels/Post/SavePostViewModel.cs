using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Internet_banking.Core.Application.ViewModels.Post
{
    public class SavePostViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "La publicacion no puede estar vacia.")]
        [DataType(DataType.Text)]
        public String? Text { get; set; }
        public String? ImgUrl { get; set; }
        public IFormFile? File { get; set; }

        public String? NuevoComentario { get; set; }
        public int Idpost { get; set; }

    }
}
