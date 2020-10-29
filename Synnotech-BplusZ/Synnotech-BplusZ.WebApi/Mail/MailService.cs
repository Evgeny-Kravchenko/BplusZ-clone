using Light.GuardClauses.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Mail
{
    public class MailService : IMailService
    {
        private readonly IMailGenerator _mailGenerator;
        private readonly IConfiguration _configuration;

        public MailService(IMailGenerator mailGenerator,
            IConfiguration configuration)
        {
            _mailGenerator = mailGenerator;
            _configuration = configuration;
        }

        public async Task SendMailAsync(Email email, bool isHtml = true)
        {
            using var client = new SmtpClient(_configuration["SmtpServerOptions:Host"],
                Convert.ToInt32(_configuration["SmtpServerOptions:Port"]))
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_configuration["SmtpServerOptions:UserName"],
                    _configuration["SmtpServerOptions:Password"])
            };

            using var mailMessage = new MailMessage
            {
                IsBodyHtml = isHtml,
                From = new MailAddress(_configuration["ContactEmail"], _configuration["ContactName"]),
                Body = email.Body,
                Subject = email.Subject,
            };

            if (email.To == null && email.To!.Count() == 0)
            {
                throw new InvalidStateException("Recipients must be specified");
            }

            foreach (var emailTo in email.To)
            {
                mailMessage.To.Add(new MailAddress(emailTo));
            }

            if (email.Attachments != null)
            {
                foreach (var attachment in email.Attachments)
                {
                    mailMessage.Attachments.Add(attachment);
                }
            }

            await client.SendMailAsync(mailMessage);
        }

        public async Task<Email> CreateEmailWithLinksTable(
            IEnumerable<string> mailTo,
            string subject,
            string baseHtmlTemplate,
            string actualHtmlTemplate,
            string rowHtmlTemplate,
            IEnumerable<Link> links,
            Dictionary<string, string>? fields = null,
            IEnumerable<Attachment>? attachments = null
           )
        {
            var pathToBaseTemplate = GeneratePathToTemplate(baseHtmlTemplate);
            var pathToActualTemplate = GeneratePathToTemplate(actualHtmlTemplate);
            var pathToRowTemplate = GeneratePathToTemplate(rowHtmlTemplate);

            var messageText = await _mailGenerator.GenerateMailMessageWithLinksTable(pathToBaseTemplate!,
                pathToActualTemplate!,
                pathToRowTemplate!,
                links,
                fields);

            var email = new Email
            {
                To = mailTo,
                Subject = subject,
                Body = messageText,
                Attachments = attachments
            };

            return email;
        }

        public Email CreateEmail(
            string mailTo,
            string subject,
            string messageText,
            IEnumerable<Attachment>? attachments = null
           )
        {
            return CreateEmail(
                new List<string> { mailTo },
                subject,
                messageText,
                attachments
                );
        }

        public Email CreateEmail(
            IEnumerable<string> mailTo,
            string subject,
            string messageText,
            IEnumerable<Attachment>? attachments = null
           )
        {
            var email = new Email
            {
                To = mailTo,
                Subject = subject,
                Body = messageText,
                Attachments = attachments
            };

            return email;
        }

        public Attachment ConvertFileToAttachment(byte[] fileAsByteArray, string fileName, string mediaType)
        {
            return new Attachment(new MemoryStream(fileAsByteArray), fileName, mediaType);
        }

        public IEnumerable<Attachment> ConvertFilesToAttachments(List<byte[]> filesAsByteArrays, string fileName, string mediaType)
        {
            var attachments = new List<Attachment>();
            foreach (var fileAsByteArray in filesAsByteArrays)
            {
                attachments.Add(ConvertFileToAttachment(fileAsByteArray, fileName, mediaType));
            }

            return attachments;
        }

        public string? GeneratePathToTemplate(string? templateName)
        {
            if (templateName == null)
            {
                return null;
            }

            var pathToTemplate = Path.Combine("Mail", "Templates", templateName);
            if (!File.Exists(pathToTemplate))
            {
                throw new InvalidStateException($"There is no template named {templateName} exists");
            }

            return pathToTemplate;
        }
    }
}
