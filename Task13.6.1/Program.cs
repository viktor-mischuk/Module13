using System.Diagnostics;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace Task13._6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("Task13.6.1.txt"))
            {
                List<string> strList = new List<string>();
                LinkedList<string> strLinkedList = new LinkedList<string>();

                // Читаем файл
                var text = sr.ReadToEnd();

                //разбиваем строку по пробелам
                var wordsT = text.Split(" ");
                ////Убираем знаки пунктуации
                var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

                // запускаем новый таймер
                var stopWatch = Stopwatch.StartNew();
                strList.AddRange(wordsT);
                stopWatch.Stop();

                // запускаем новый таймер
                var stopWatchLinked = Stopwatch.StartNew();
                foreach (var word in wordsT)
                {
                    strLinkedList.AddLast(word);
                }
                
                stopWatchLinked.Stop();


                // смотрим, сколько операция заняла, в миллисекундах
                Console.WriteLine($"Не связный список : {stopWatch.Elapsed.TotalMilliseconds} мс");
                Console.WriteLine();

                Console.WriteLine($"Связный список : {stopWatchLinked.Elapsed.TotalMilliseconds} мс");
                Console.ReadKey();
            }           
        }
    }
}
