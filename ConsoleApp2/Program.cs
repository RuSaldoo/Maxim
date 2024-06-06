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



        static string CheckStr(ref string str)  //Возможно ref ломает
        {
            char[] EngLitter = { 'a', 'b', 'c', 'd', 'e',
                'f', 'g', 'h', 'i','j', 'k',
                'l', 'm', 'n', 'o', 'p', 'q',
                'r', 's', 't', 'u', 'v', 'w',
                'x', 'y', 'z'
            };

            string rezult = null;
            var CharArr = str.ToCharArray();
            int qua_lit = CharArr.Except(EngLitter).Count();

            if (0 == qua_lit) //возможно подразумевалось try catch
            {
                rezult = StringRevers(str);
            }
            else
            {
                Console.WriteLine("Неверно введено сообщение!");
                foreach (char i in CharArr.Except(EngLitter))
                {
                    rezult += " "+i;
                }
                rezult = "Неверрно введённые символы = " + rezult;
            }
            return rezult;
        }



        public static string StringRevers(string PullString)
        {
            if (PullString.Length % 2 == 0)
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
            Console.WriteLine(CheckStr(ref string1));
            Console.ReadLine();
        }
    }
}
