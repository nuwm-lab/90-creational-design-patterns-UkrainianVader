using System;
using LabWork.Builders;

namespace LabWork
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var builder = new SimpleDocumentBuilder();
                var director = new Director();

                ShowUserGuideDemo(director, builder);

                // Повторно використовуємо builder для реліз-нотаток
                builder.Reset()
                       .AddHeading("Release Notes")
                       .AddSection("v1.0", "Initial release with builder implementation.")
                       .AddFootnote("See CHANGELOG for full details.");

                ShowReleaseNotesDemo(builder);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        private static void ShowUserGuideDemo(Director director, SimpleDocumentBuilder builder)
        {
            // Демонстрація використання патерну Builder для створення документації
            director.BuildUserGuide(builder);
            var userGuideDoc = builder.Build();

            Console.WriteLine("--- User Guide ---");
            Console.WriteLine();
            Console.WriteLine(userGuideDoc.Render());
        }

        private static void ShowReleaseNotesDemo(SimpleDocumentBuilder builder)
        {
            var releaseNotesDoc = builder.Build();

            Console.WriteLine("--- Release Notes ---");
            Console.WriteLine();
            Console.WriteLine(releaseNotesDoc.Render());
        }
    }
}
