using System;
using LabWork;
using LabWork.Builders;

namespace LabWork
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                IDocumentBuilder builder = new SimpleDocumentBuilder();
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
                // Виводимо повну інформацію про виключення та повертаємо код помилки
                Console.Error.WriteLine(ex.ToString());
                Environment.Exit(1);
            }
        }

        private static void ShowUserGuideDemo(Director director, IDocumentBuilder builder)
        {
            // Демонстрація використання патерну Builder для створення документації
            director.BuildUserGuide(builder);
            var userGuideDoc = builder.Build();

            Console.WriteLine("--- User Guide ---");
            Console.WriteLine();
            Console.WriteLine(userGuideDoc.Render());
        }

        private static void ShowReleaseNotesDemo(IDocumentBuilder builder)
        {
            var releaseNotesDoc = builder.Build();

            Console.WriteLine("--- Release Notes ---");
            Console.WriteLine();
            Console.WriteLine(releaseNotesDoc.Render());
        }
    }
}
