using Internet_banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Entities
{
    public class Comments : AuditableBaseEntity
    {
        public String? Text { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }


        public Post? Post { get; set; }
    }
}
