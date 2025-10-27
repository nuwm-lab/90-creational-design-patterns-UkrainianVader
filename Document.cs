using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork
{
    // Модель документа: складається з секцій і виносок
    public class Document
    {
        public List<Section> Sections { get; } = new List<Section>();
        public List<Footnote> Footnotes { get; } = new List<Footnote>();

        public void AddSection(Section section)
        {
            Sections.Add(section);
        }

        public void AddFootnote(Footnote footnote)
        {
            Footnotes.Add(footnote);
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
        public string Heading { get; set; }
        public string Content { get; set; }

        public Section(string heading, string content)
        {
            Heading = heading;
            Content = content;
        }
    }

    public class Footnote
    {
        public string Text { get; set; }

        public Footnote(string text)
        {
            Text = text;
        }
    }
}
