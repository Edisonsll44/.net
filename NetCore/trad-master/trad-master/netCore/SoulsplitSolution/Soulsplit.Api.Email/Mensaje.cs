using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace Soulsplit.Api.Email
{
    public class Mensaje
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public Dictionary<string, string> Content { get; set; }

        public Mensaje(IEnumerable<string> to, string subject, Dictionary<string, string> content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Content = content;
        }
    }
}
