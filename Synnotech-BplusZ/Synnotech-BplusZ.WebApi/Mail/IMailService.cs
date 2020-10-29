using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Mail
{
    public interface IMailService
    {
        IEnumerable<Attachment> ConvertFilesToAttachments(List<byte[]> filesAsByteArrays, string fileName, string mediaType);
        Attachment ConvertFileToAttachment(byte[] fileAsByteArray, string fileName, string mediaType);
        Email CreateEmail(string mailTo, string subject, string messageText, IEnumerable<Attachment>? attachments = null);
        Email CreateEmail(IEnumerable<string> mailTo, string subject, string messageText, IEnumerable<Attachment>? attachments = null);
        Task<Email> CreateEmailWithLinksTable(IEnumerable<string> mailTo, string subject, string baseHtmlTemplate, string actualHtmlTemplate, string rowHtmlTemplate, IEnumerable<Link> links, Dictionary<string, string>? fields = null, IEnumerable<Attachment>? attachments = null);
        Task SendMailAsync(Email email, bool isHtml = true);
    }
}
