using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Light.GuardClauses.Exceptions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Mail
{
    public class MailGenerator : IMailGenerator
    {
        public async Task<string> GenerateMailMessageWithLinksTable(string baseHtmlTemplatePath,
            string actualHtmlTemplatePath,
            string rowHtmlTemplatePath,
            IEnumerable<Link> links,
            Dictionary<string, string>? fields)
        {
            var baseHtmlTemplateDom = await GetDom(baseHtmlTemplatePath);
            var actualHtmlTemplateDom = await GetDom(actualHtmlTemplatePath);

            var rowHtmlTemplateDom = await GetDom(rowHtmlTemplatePath);
            GenerateLinkRowsAndFillTable(actualHtmlTemplateDom!, rowHtmlTemplateDom!, links);

            FillBody(baseHtmlTemplateDom!, actualHtmlTemplateDom!);
            var htmlMailMessage = GetFilledHtmlMessage(baseHtmlTemplateDom!, fields);

            return htmlMailMessage;
        }

        private async Task<IDocument?> GetDom(string? htmlTemplatePath)
        {
            if (htmlTemplatePath == null)
            {
                return null;
            }

            using var htmlTemplateStream = File.Open(htmlTemplatePath, FileMode.Open);
            var browsingContext = BrowsingContext.New(Configuration.Default);
            var dom = await browsingContext.OpenAsync(response => response.Content(htmlTemplateStream));

            return dom;
        }

        private void GenerateLinkRowsAndFillTable(IDocument actualHtmlTemplateDom, 
            IDocument rowHtmlTemplateDom, 
            IEnumerable<Link> links)
        {
            if (actualHtmlTemplateDom != null)
            {
                var table = actualHtmlTemplateDom.GetElementsByClassName("table").FirstOrDefault();
                if (table == null)
                {
                    throw new InvalidStateException("There is no such element with id = 'table'");
                }

                var anchorElement = rowHtmlTemplateDom.GetElementsByTagName("A").FirstOrDefault();
                if (anchorElement != null && anchorElement is IHtmlAnchorElement anchor)
                {
                    foreach (var link in links)
                    {
                        anchor.Href = link.Href ?? string.Empty;
                        anchor.TextContent = link.Content ?? string.Empty;

                        table.InnerHtml += rowHtmlTemplateDom.Body.InnerHtml;
                    }
                }
                else
                {
                    throw new InvalidStateException("There are no anchors in this template");
                }
            }
        }

        private string GetFilledHtmlMessage(IDocument baseHtmlTemplateDom,
            Dictionary<string, string>? fields)
        {
            FillFields(baseHtmlTemplateDom, fields);

            return baseHtmlTemplateDom.DocumentElement.ToHtml();
        }

        private void FillFields(IDocument htmlTemplateDom, Dictionary<string, string>? fields)
        {
            if (fields == null)
            {
                return;
            }

            foreach (var field in fields!)
            {
                var element = htmlTemplateDom.GetElementById(field.Key);
                if (element == null)
                {
                    continue;
                }

                if (element.TagName == "A" && element is IHtmlAnchorElement)
                {
                    (element as IHtmlAnchorElement)!.Href = field.Value;
                }
                else
                {
                    element.TextContent = field.Value;
                }
            }

        }

        private void FillBody(IDocument baseHtmlTemplateDom, IDocument actualHtmlTemplateDom)
        {
            var header = baseHtmlTemplateDom.GetElementById("container");
            if (header == null)
            {
                throw new InvalidStateException("There is no such element with id = 'container'");
            }

            header.InnerHtml = actualHtmlTemplateDom.Body.InnerHtml;
        }
    }
}
