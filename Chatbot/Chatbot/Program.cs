using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{

    public class Chatbot
    {
        // Respond to Basic Queries
        public string RespondToQuery(string query)
        {
            Console.WriteLine($"Basic query received: {query}");
            // Basic query processing logic
            if (query.ToLower().Contains("help"))
            {
                return "Sure, how can I help you?";
            }
            else if (query.ToLower().Contains("order status"))
            {
                return "Please provide your order number.";
            }
            else
            {
                return "I'm sorry, I don't understand. Could you please rephrase your query?";
            }
        }

        // Respond to Priority Queries
        public string RespondToQuery(string query, bool isPriority)
        {
            Console.WriteLine($"Priority query received: {query}");
            // Priority query processing logic
            if (isPriority)
            {
                return "This is a priority query. Please wait while I escalate it to a human agent.";
            }
            else
            {
                return RespondToQuery(query); // Fallback to basic response
            }
        }

        // Respond to Multi-Language Queries
        public string RespondToQuery(string query, string languageCode)
        {
            Console.WriteLine($"Multi-language query received ({languageCode}): {query}");
            // Multi-language query processing logic
            Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>()
        {
            { "help", new Dictionary<string, string>() { { "en", "Sure, how can I help you?" }, { "es", "Claro, ¿cómo puedo ayudarte?" }, { "fr", "Bien sûr, comment puis-je vous aider ?" } } },
            { "order status", new Dictionary<string, string>() { { "en", "Please provide your order number." }, { "es", "Por favor, proporcione su número de pedido." }, { "fr", "Veuillez fournir votre numéro de commande." } } },
            { "default", new Dictionary<string, string>() { { "en", "I'm sorry, I don't understand. Could you please rephrase your query?" }, { "es", "Lo siento, no entiendo. ¿Podría reformular su pregunta?" }, { "fr", "Je suis désolé, je ne comprends pas. Pourriez-vous reformuler votre question ?" } } }

        };

            string lowercaseQuery = query.ToLower();

            foreach (var keyword in translations.Keys)
            {
                if (lowercaseQuery.Contains(keyword))
                {
                    if (translations[keyword].ContainsKey(languageCode))
                    {
                        return translations[keyword][languageCode];
                    }
                    else
                    {
                        return translations[keyword]["en"]; // Default to english if no translation exists.
                    }

                }
            }
            return translations["default"][languageCode]; //Default response.

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Chatbot chatbot = new Chatbot();

            // Basic Query
            string basicResponse = chatbot.RespondToQuery("Help");
            Console.WriteLine($"Chatbot: {basicResponse}");

            // Priority Query
            string priorityResponse = chatbot.RespondToQuery("Urgent issue", true);
            Console.WriteLine($"Chatbot: {priorityResponse}");

            // Multi-Language Query
            string spanishResponse = chatbot.RespondToQuery("Ayuda", "es");
            Console.WriteLine($"Chatbot: {spanishResponse}");

            string frenchResponse = chatbot.RespondToQuery("statut de la commande", "fr");
            Console.WriteLine($"Chatbot: {frenchResponse}");

            string unknownLanguage = chatbot.RespondToQuery("Help", "de");
            Console.WriteLine($"Chatbot: {unknownLanguage}");
        }
    }
}
