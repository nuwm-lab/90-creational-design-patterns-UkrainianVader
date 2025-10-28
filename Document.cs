using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork
{
    // Модель документа: складається з секцій і виносок
    public class Document : IDocument
    {
        private readonly List<Section> _sections = new List<Section>();
        private readonly List<Footnote> _footnotes = new List<Footnote>();

        public IReadOnlyList<Section> Sections => _sections.AsReadOnly();
        public IReadOnlyList<Footnote> Footnotes => _footnotes.AsReadOnly();

        public void AddSection(Section section)
        {
            if (section == null) throw new ArgumentNullException(nameof(section));
            _sections.Add(section);
        }

        public void AddFootnote(Footnote footnote)
        {
            if (footnote == null) throw new ArgumentNullException(nameof(footnote));
            _footnotes.Add(footnote);
        }

        // Просте рендерення у Markdown-подібний текст
        public string Render()
        {
            var sb = new StringBuilder();

            foreach (var sec in Sections)
            {
                if (!string.IsNullOrEmpty(sec.Heading))
                {
                    sb.AppendLine($"## {sec.Heading}");
                }

                if (!string.IsNullOrEmpty(sec.Content))
                {
                    sb.AppendLine(sec.Content);
                }

                sb.AppendLine();
            }

            if (Footnotes.Count > 0)
            {
                sb.AppendLine("---");
                sb.AppendLine("### Footnotes");
                int i = 1;
                foreach (var f in Footnotes)
                {
                    sb.AppendLine($"[{i}] {f.Text}");
                    i++;
                }
            }

            return sb.ToString();
        }
    }

    public class Section
    {
        public string Heading { get; }
        public string Content { get; }

        public Section(string heading, string content)
        {
            Heading = heading ?? throw new ArgumentNullException(nameof(heading));
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }
    }

    public class Footnote
    {
        public string Text { get; }

        public Footnote(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
