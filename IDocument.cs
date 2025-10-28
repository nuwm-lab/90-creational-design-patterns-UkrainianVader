using System;

namespace LabWork
{
    /// <summary>
    /// Абстракція документа, що дозволяє приховати конкретну реалізацію <see cref="Document"/>.
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// Повертає текстове представлення документа.
        /// </summary>
        string Render();
    }
}
