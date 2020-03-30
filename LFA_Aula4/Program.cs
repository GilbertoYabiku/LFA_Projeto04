using LFA_Aula4.Classes;
using System;
using System.Collections.Generic;

namespace LFA_Aula4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> symbolsList = new List<char>{ 'a', 'b', 'c', 'S', 'B', 'C' };
            List<char> finalSymbolsList = new List<char> { 'a', 'b', 'c' };
            Rule rule1 = new Rule { De = "S", Para = "aSBC" };
            Rule rule2 = new Rule { De = "S", Para = "abC" };
            Rule rule3 = new Rule { De = "CB", Para = "BC" };
            Rule rule4 = new Rule { De = "bB", Para = "bb" };
            Rule rule5 = new Rule { De = "cC", Para = "cc" };
            List<Rule> rules = new List<Rule>{ rule1, rule2, rule3, rule4, rule5 };
            char initialSymbol = 'S';
            List<string> sentences = new List<string>();
            for (int i = 0; i < 20; i++)
            {
               
                sentences.Add(formSentence(symbolsList, finalSymbolsList, rules, initialSymbol, i));
                
            }
            
            Console.ReadLine();
        }

        public static string formSentence (List<char> symbolsList, List<char> finalSymbolsList, List<Rule> rules, char initialSymbol, int count)
        {
            string sentence = initialSymbol.ToString();
            List<bool> rulesApplied = new List<bool>();
            bool finalSentence = false, allRulesApplied = false, nextTest = false;
            string testSentence = null;
            Random random = new Random();
            int countFinal = 0;
            for (int i = 0; i < count+1; i++)
            {
                if (sentence.Contains(initialSymbol.ToString()))
                {
                    sentence = sentence.Replace(rules[0].De, rules[0].Para);
                }
                
            }
           
            for(int j = 0; j < rules.Count;j++)
            {
                       
                rulesApplied.Add(false);
            }
            do
            {
                for (int i = 0; i < rules.Count; i++)
                {
                    do
                    {
                        int randomRule = random.Next(0, rules.Count);
                        rulesApplied[randomRule] = true;

                        if (sentence.Contains(rules[randomRule].De))
                        {
                            sentence = sentence.Replace(rules[randomRule].De, rules[randomRule].Para);
                        }

                    } while (rulesApplied.Contains(false));
                }
               

                testSentence = sentence;

                foreach (var symbol in finalSymbolsList)
                {
                    testSentence = testSentence.Replace(symbol.ToString(), "");
                }
                if(testSentence.Equals(""))
                {
                    finalSentence = true;
                }
                countFinal++;
                if(countFinal == 100)
                {
                    return null;
                }
            } while (!finalSentence);
            Console.WriteLine(sentence);
            return sentence;
        }
    }
}
