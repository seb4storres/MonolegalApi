using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> to, string subject, string content) 
        {
            To = new List<MailboxAddress>();
            string name = string.Empty;
            To.AddRange(to.Select(x => new MailboxAddress(name, x)));
            Subject = subject;
            Content = content;

        }
    }
}
