using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Settings
{
    public class MailSettings
    {
        public String EmailFrom { get; set; }
        public String SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public String SmtpUser { get; set; }
        public String SmtpPass { get; set; }
        public String DisplayName { get; set; }
    }
}
