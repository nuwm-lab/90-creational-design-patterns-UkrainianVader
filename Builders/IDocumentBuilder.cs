using System;
using System.Collections.Generic;
using LabWork;

namespace LabWork.Builders
{
    /// <summary>
    /// Контракт для побудови <see cref="Document"/>.
    /// </summary>
    public interface IDocumentBuilder
    {
        IDocumentBuilder Reset();
        IDocumentBuilder AddSection(string heading, string content);
        IDocumentBuilder AddHeading(string heading); // adds a heading-only section
        IDocumentBuilder AddFootnote(string text);
        /// <summary>
        /// Повертає збудований документ. Реалізації можуть скинути внутрішній стан після повернення результату.
        /// Повертає абстракцію <see cref="IDocument"/>, щоб приховати конкретну реалізацію.
        /// </summary>
        IDocument Build();
    }
}
