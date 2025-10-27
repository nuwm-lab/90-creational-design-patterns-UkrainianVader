using System;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 
    class Program
    {
        static void Main(string[] args)
        {
            // Демонстрація використання патерну Builder для створення документації
            var builder = new Builders.SimpleDocumentBuilder();
            var director = new Builders.Director();

            // Побудуємо короткий User Guide
            director.BuildUserGuide(builder);
            var userGuide = builder.Build();

            Console.WriteLine("--- User Guide ---\n");
            Console.WriteLine(userGuide.Render());

            // Приклад ручної побудови: секції + виноски
            builder.Reset()
                   .AddHeading("Release Notes")
                   .AddSection("v1.0", "Initial release with builder implementation.")
                   .AddFootnote("See CHANGELOG for full details.");

            var notes = builder.Build();
            Console.WriteLine("--- Release Notes ---\n");
            Console.WriteLine(notes.Render());
        }
    }
}
