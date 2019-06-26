using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net;
using System.Text;
using System.Collections;

namespace HmWrk3_Tekst
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern1 = @"[\(\)\[\]\<\>\*_']";
            string pattern2 = "[\"]";
            string pattern3 = @"([A-Za-z\d\\s]+[^.!?]*[.?!\n])";
            string pattern4 = @"(\b\w*\b)";
            string pattern5 = @"([,.!?:;])";
            string tx1;

            using (StreamReader text = new StreamReader("e:/Учеба C#/Дом раб3/tx.txt"))
            {
                tx1 = text.ReadToEnd();
            }                   
                var tx3 = Regex.Replace(tx1, pattern1,"");
                var CleanedText = Regex.Replace(tx3, pattern2,"");//text cleared from ()[]<>*_'"

            string[] SplitTextSentence = new Regex(pattern3).Split(CleanedText); //text split  on sentences
            string[] SplitTextWord = new Regex(pattern4).Split(CleanedText); //text split  on words
            string[] SplitPunctMarks = new Regex(pattern5).Split(CleanedText); //text split on punctuation marks
            var TextWordOrderByAlphabet = SplitTextWord.OrderBy(i => i); //Words order by alphabet



            //List<string> TextWordOrder = new List<string>();
            //foreach (var i in TextWordOrderByAlphabet)
            //{
            //    TextWordOrder.Add(i);
            //}
            //using (StreamWriter sw = new StreamWriter("e:/Учеба C#/Дом раб3/TextWordOrderCount.txt"))
            //{
            //    foreach (var i in TextWordOrder)
            //    {
            //        var cnt = (from x in TextWordOrder
            //                   where x == i
            //                   select x).Count();
            //        sw.WriteLine($"Word:{i}, is found: {cnt}");


            //    }
            //}
            //ЭТОЙ ЧАСТЬЮ КОДА ХОТЕЛ ВЫВЕСТИ ДЛЯ КАЖДОГО ЭЛЕМЕНТА, ОТСОРТИРОВАННОГО РАНЕЕ ПО АЛФОВИТУ, 
            //КОЛИЧЕСТВО РАЗ ИСПОЛЬЗОВАНИЯ, НО ПРИ ЗАПУСКЕ КОМП ОЧЕНЬ НАДОЛГО ЗАДУМЫВАЕТСЯ....ПРИХОДИТСЯ ПРЕРЫВАТЬ
            //ВИДИМО ЧТО ТО НЕ ТО


            using (StreamWriter sw = new StreamWriter("e:/Учеба C#/Дом раб3/SplitTextSentence.txt")) //text was splited on Sentence and record in file SplitTextSentence.txt
            {
                foreach (var i in SplitTextSentence)
                {
                    sw.WriteLine(i);
                }
            }
            using (StreamWriter sw = new StreamWriter("e:/Учеба C#/Дом раб3/SplitTextWord.txt"))
            {
                foreach (var i in SplitTextWord)  //text was splited on words and record in file SplitTextWord.txt
                {
                    if (String.IsNullOrWhiteSpace(i)==false)
                       sw.WriteLine(i);
                }
            }
            using (StreamWriter sw = new StreamWriter("e:/Учеба C#/Дом раб3/SplitPunctMarks.txt"))
            {
                foreach (var i in SplitPunctMarks)  //text was splited on punctuation marks and record in file SplitPunctMarks
                {
                    if (String.IsNullOrWhiteSpace(i) == false)
                        sw.WriteLine(i);
                }
            }
            using (StreamWriter sw = new StreamWriter("e:/Учеба C#/Дом раб3/TextWordOrderByAlphabet.txt"))
            {

                foreach (var i in TextWordOrderByAlphabet)  //text was splited on words and order by alphabet and record in file TextWordOrderByAlphabet.txt
                {
                    if (String.IsNullOrWhiteSpace(i) == false)
                        sw.WriteLine(i);
                }
            }

        }

    }
}
