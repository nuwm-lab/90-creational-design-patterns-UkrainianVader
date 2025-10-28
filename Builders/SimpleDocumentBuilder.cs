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

        /// <summary>
        /// Повертає збудований документ як <see cref="IDocument"/>. Після повернення реалізація скидає внутрішній стан
        /// (викликає <see cref="Reset"/>), щоб будівник можна було повторно використовувати.
        /// Це поведінка, яку слід документувати для споживачів інтерфейсу.
        /// </summary>
        public IDocument Build()
        {
            var result = _document;
            // Reset builder so it can be reused by the caller. This behavior is intentional.
            Reset();
            return result;
        }
    }
}
