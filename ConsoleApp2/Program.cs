using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    internal class Program
    {
        private static string StringRevers(string PullString)
        {                                                       //   abc def          cda fed   
            if (PullString.Length % 2 == 0)                     //   123 456          321 654
            {
                char[] arr = PullString.ToCharArray();
                int len = (PullString.Length / 2);
                Array.Reverse(arr);
                string Furst_part = new string(arr).Substring(len);
                string Last_part = new string(arr).Substring(0, len);
                string rezult = Furst_part + Last_part;
                return rezult;
            }
            else
            {
                var arr = PullString.ToCharArray();
                Array.Reverse(arr);
                string Furst_part = new string(arr);
                string rezult = Furst_part + PullString;
                return rezult;
            }
        }


        static void Main(string[] args)
        {
            string string1 = Console.ReadLine();
            Console.WriteLine(StringRevers(string1));
            Console.ReadLine();
        }
    }
}
