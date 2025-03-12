using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequency
{
    

    public class WordFrequency
    {
        public static void Main(string[] args)
        {
            string text = "This is an example text. This text contains some words. Some words appear multiple times.";

            // 1. Count occurrences of each word.
            var wordCounts = text.ToLower()
                .Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(word => word)
                .Select(group => new { Word = group.Key, Count = group.Count() })
                .ToList();

            // 2. Display words and their frequencies in descending order.
            var sortedWordCounts = wordCounts.OrderByDescending(wc => wc.Count);

            Console.WriteLine("Word Frequencies:");
            foreach (var wordCount in sortedWordCounts)
            {
                Console.WriteLine($"Word: {wordCount.Word}, Frequency: {wordCount.Count}");
            }

            Console.ReadKey();
        }
    }
}
