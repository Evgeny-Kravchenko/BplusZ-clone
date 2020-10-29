using System.Collections.Generic;
using System.Net.Mail;

namespace Synnotech_BplusZ.WebApi.Mail
{
    public class Email
    {
        public IEnumerable<string>? To { get; set; }

        public string? Subject { get; set; }

        public string? Body { get; set; }

        public IEnumerable<Attachment>? Attachments { get; set; }
    }
}
