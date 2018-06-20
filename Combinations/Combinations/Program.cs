using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {

            GetCombination(new List<int> { 60, 60, 60, 60, 60, 45, 45, 45, 45, 45, 45, 30 },180);  

        }

        static void GetCombination(List<int> talkMinutes,int maxTime)
        {
            var talkMinsForPartOfDay = new List<int>();
            
            var count = Math.Pow(2, talkMinutes.Count); 
            for (var i = 1; i <= count - 1; i++)
            {
                var str = Convert.ToString(i, 2).PadLeft(talkMinutes.Count, '0');
                var temp = new List<int>();
                var total = 0;
                for (var j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        //Console.Write(talkMinutes[j]);
                        temp.Add(talkMinutes[j]);
                        total +=talkMinutes[j];
                    }
                }

                if (total == maxTime)
                {
                    Console.WriteLine(String.Join(' ',temp));
                    Console.WriteLine(total);
                    break;
                }
                
            }
        }
        
        
    }
}