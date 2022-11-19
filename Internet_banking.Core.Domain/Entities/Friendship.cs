using Internet_banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Entities
{
    public  class Friendship : AuditableBaseEntity
    {

        public int IdUser { get; set; }
        public int IdFriend { get; set; }

    }
}
