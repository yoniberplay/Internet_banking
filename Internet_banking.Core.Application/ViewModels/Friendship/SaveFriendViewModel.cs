using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Friendship
{
    public class SaveFriendViewModel
    {

        [Required(ErrorMessage = "No puede esta vacio")]
        [DataType(DataType.Text)]
        public string amigo { get; set; }

        public int IdUser { get; set; }
        public int IdFriend { get; set; }

    }
}
