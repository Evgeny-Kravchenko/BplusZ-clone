using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Mail
{
    public interface IMailGenerator
    {
        Task<string> GenerateMailMessageWithLinksTable(string baseHtmlTemplatePath, string actualHtmlTemplatePath, string rowHtmlTemplatePath, IEnumerable<Link> links, Dictionary<string, string>? fields);
    }
}
