using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Dtos.Email
{
    public class EmailRequest
    {
        public String To { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public String From { get; set; }
    }
}
