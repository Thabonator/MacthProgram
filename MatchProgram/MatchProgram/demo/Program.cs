using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace demo
{
    class Program
    {
        public static void CalculateMatch(string name1,string name2)
        {
            try
            {

                string sentence = name1.ToLower() + "matches" + name2.ToLower();
                string s = "";
                string t = "";
                double l = 0;
                List<int> seclist = new List<int>();
                List<int> list = new List<int>();
                while (sentence != "")
                {
                    int i = 0;
                    char firstLetter = char.Parse(sentence.Substring(0, 1));
                    list.Add(sentence.Count(f => f == firstLetter));
                    sentence = sentence.Replace(firstLetter.ToString(), "");
                    i = i++;
                }
                foreach (int num in list)
                {
                    s = s + num.ToString();
                }
                l = double.Parse(s);

                do
                {
                    int b = 0;
                    if (s.Length > 1)
                    {

                        b = int.Parse(s.Substring(0, 1)) + int.Parse(s.Substring(s.Length - 1, 1));
                        t = t + b.ToString();
                        s = s.Remove(0, 1);
                        s = s.Remove(s.Length - 1, 1);
                    }
                    else
                    {
                        t = t + s.Substring(0, 1);
                        l = double.Parse(t);
                        s = "";
                    }


                    if (double.Parse(t) > 100 && s == "")
                    {
                        s = t;
                        t = "";
                    }

                } while (s != "" && l > 100);
                if (l >= 80)
                {
                    Console.WriteLine(name1 + " matches " + name2 + " " + l + "%, good match");
                }
                else
                {
                    Console.WriteLine(name1 + " matches " + name2 + " " + l + "%");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void CalculateMatch(String csvPath)
        {
            try
            {
                var reader = new StreamReader(File.OpenRead(@csvPath));
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                List<string> males = new List<string>();
                List<string> females = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[1]);


                }
                for (int a = 0; a < listB.Count; a++)
                {

                    if (listB[a] == "m")
                    {

                        if (!males.Contains(listA[a]))
                        {
                            males.Add(listA[a]);
                        }
                    }
                    else
                    {

                        if (!females.Contains(listA[a]))
                        {
                            females.Add(listA[a]);
                        }
                    }

                }


                for (int i = 0; i < males.Count; i++)
                {
                    for (int j = 0; j < females.Count; j++)
                    {
                        CalculateMatch(males[i], females[j]);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
        public static async Task SaveToTxt(string line)
        {
            await File.WriteAllTextAsync("output.txt", line);
        }
        static void Main(string[] args)
        {
            //CalculateMatch("jack", "jill");
            Console.WriteLine("Please Select (1 or 2) Match Option \n1. Input Names\n2. Input CSV Path");
            string input = Console.ReadLine();
            if(input == "1")
            {
                Console.Write("Enter the First Name: ");
                string first = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter the Second Name: ");
                string second = Console.ReadLine();
                Console.WriteLine();
                CalculateMatch (first, second);
            }
            else if(input=="2")
            {
                Console.WriteLine("Enter CSV File Path");
                string path = Console.ReadLine();
                CalculateMatch(path);

            }
            else
            {
                Console.WriteLine("Wrong Input entered try again");
            }
            

        }

    }
}
