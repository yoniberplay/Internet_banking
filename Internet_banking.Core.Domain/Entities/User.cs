using Internet_banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {        
        public string? Username { get; set; }
        
        public string? Password { get; set; }
     
        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
     
        public string? Phone { get; set; }

        public string? Photo { get; set; }

        
        public ICollection<Post>? Post { get; set; }
        public ICollection<Friendship>? Friendship { get; set; }
    }
}
