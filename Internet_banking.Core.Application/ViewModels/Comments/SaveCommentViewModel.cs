using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Comments
{
    public class SaveCommentViewModel
    {
        [Required(ErrorMessage = "El comentario no puede estar en blanco")]
        [DataType(DataType.Text)]
        public String? Text { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
