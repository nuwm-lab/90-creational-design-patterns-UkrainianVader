using System;
using LabWork;

namespace LabWork.Builders
{
    public class SimpleDocumentBuilder : IDocumentBuilder
    {
        private Document _document;

        public SimpleDocumentBuilder()
        {
            Reset();
        }

        public IDocumentBuilder Reset()
        {
            _document = new Document();
            return this;
        }

        public IDocumentBuilder AddSection(string heading, string content)
        {
            _document.AddSection(new Section(heading, content));
            return this;
        }

        public IDocumentBuilder AddHeading(string heading)
        {
            _document.AddSection(new Section(heading, string.Empty));
            return this;
        }

        public IDocumentBuilder AddFootnote(string text)
        {
            _document.AddFootnote(new Footnote(text));
            return this;
        }

        public Document Build()
        {
            var result = _document;
            // Optionally reset so builder can be reused
            Reset();
            return result;
        }
    }
}
