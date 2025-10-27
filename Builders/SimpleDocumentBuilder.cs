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
            if (heading == null) throw new ArgumentNullException(nameof(heading));
            if (content == null) throw new ArgumentNullException(nameof(content));
            _document.AddSection(new Section(heading, content));
            return this;
        }

        public IDocumentBuilder AddHeading(string heading)
        {
            if (heading == null) throw new ArgumentNullException(nameof(heading));
            _document.AddSection(new Section(heading, string.Empty));
            return this;
        }

        public IDocumentBuilder AddFootnote(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
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
