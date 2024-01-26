using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace Task13._6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> wordsList = new List<string>();
            Dictionary<string, int> wordDict = new Dictionary<string, int>();

            using (var sr = new StreamReader("Task13.6.2.txt"))
            {
                string line = null;
                while(null != (line = sr.ReadLine()))
                {
                    //разбиваем строку по пробелам
                    var wordsT = line.Split(" ");

                    string wordsTT;
                    foreach(var word in wordsT)
                    {
                        //только юуквы
                        wordsTT = new string(word.Where(c => char.IsLetter(c)).ToArray());
                        if (string.IsNullOrEmpty(wordsTT)) continue;
                        // Если один символ, считаем что это не слово (союзы не считаем)
                        if(wordsTT.Length < 2) continue;
                        //все к верхнему регистру для единообразия
                        wordsList.Add(wordsTT.ToUpper());
                    }

                }
                //Упорядчиваем список
                wordsList.Sort();

                //счетчик вхождений
                int i = 0;
                //текущее слово
                var curr = wordsList[0];
                foreach (var word in wordsList)
                {
                    if (word == curr) i++; 
                    else
                    {
                        //словарь  -ключ слово - значение частота вхождения
                        wordDict.Add(curr, i);
                        curr = word;
                        i = 1;
                    }
                }
            }
            // список частот вхождения
            List<int> enterNumbers = new List<int>();
            foreach (var value in wordDict.Values)
            {
                enterNumbers.Add(value);
            }
            // сортируум по значению
            enterNumbers.Sort();
            // удаляем дубликаты
            enterNumbers.Distinct();
            // разворачиваем от большего к меньшему
            enterNumbers.Reverse();
            // 10 наибольших значений частоты вхождения
            var enterRange = enterNumbers.GetRange(0, 10);
            
            foreach(var item in enterRange)
            {
                int counter = 0;
                string str = null;
                foreach (var key in wordDict.Keys) 
                { 
                    if(wordDict[key] != item) { continue; }
                    counter = wordDict[key];
                    str = key;
                }
                Console.WriteLine($"Слово '{str}'     используется {counter} раз");
            }
            Console.ReadKey();
        }
    }
}
