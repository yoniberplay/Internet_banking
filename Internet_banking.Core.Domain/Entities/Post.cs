using Internet_banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Entities
{
    public class Post : AuditableBaseEntity
    {

        public int UserId { get; set; }
        public String? Text { get; set; }
        public String? ImgUrl { get; set; }

        public ICollection<Comments>? Comments { get; set; }

    }
}
