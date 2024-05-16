using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть текст: ");
        string text = Console.ReadLine();

        string pattern = @"\b\d{2}\.\d{2}\.\d{4}\b"; // Регулярний вираз для дат у форматі "дд.мм.рррр"
        Regex regex = new Regex(pattern);

        MatchCollection matches = regex.Matches(text);

        if (matches.Count > 0)
        {
            Console.WriteLine("Знайдені дати:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
        else
        {
            Console.WriteLine("Дати у форматі 'дд.мм.рррр' не знайдені.");
        }

        Console.ReadLine();
    }
}