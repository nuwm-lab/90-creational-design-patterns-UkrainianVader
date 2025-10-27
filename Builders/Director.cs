using System;

namespace LabWork.Builders
{
    // Director демонструє стандартні варіанти складання документа
    public class Director
    {
        public void BuildUserGuide(IDocumentBuilder builder)
        {
            builder.Reset()
                   .AddHeading("User Guide")
                   .AddSection("Introduction", "This guide explains how to use the product.")
                   .AddSection("Getting Started", "Installation and quick start steps.")
                   .AddFootnote("This guide is illustrative.");
        }

        public void BuildApiSpec(IDocumentBuilder builder)
        {
            builder.Reset()
                   .AddHeading("API Specification")
                   .AddSection("Endpoints", "List of endpoints and descriptions.")
                   .AddSection("Authentication", "Auth scheme and examples.")
                   .AddFootnote("API version 1.0");
        }
    }
}
