using System;
using System.Collections.Generic;

namespace LabWork.Builders
{
    public interface IDocumentBuilder
    {
        IDocumentBuilder Reset();
        IDocumentBuilder AddSection(string heading, string content);
        IDocumentBuilder AddHeading(string heading); // adds a heading-only section
        IDocumentBuilder AddFootnote(string text);
        LabWork.Document Build();
    }
}
