using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static List<char> vowelLetters = new List<char> { 'a', 'e', 'i', 'o', 'u', 'y', };
        static string CheckStr(ref string str)  //Возможно ref ломает
        {
            var EngLitter = new List<char> { 'a', 'b', 'c', 'd', 'e',
                'f', 'g', 'h', 'i','j', 'k',
                'l', 'm', 'n', 'o', 'p', 'q',
                'r', 's', 't', 'u', 'v', 'w',
                'x', 'y', 'z'
            };

            string rezult = null;
            var CharArr = new List<char>(str.ToCharArray());
            int qua_lit = CharArr.Except(EngLitter).Count();

            if (0 == qua_lit)
            {
                rezult = StringRevers(str);
            }

            else
            {
                Console.WriteLine("Неверно введено сообщение!");
                foreach (char i in CharArr.Except(EngLitter))
                    rezult += " " + i;

                rezult = "Неверрно введённые символы = " + rezult;
            }                               //Невернно ведённые символы

            return rezult;
        }




        public static string OptionSort(string inputString)
        {
            Console.WriteLine("\nВыберите тип сортировки:\n1 Быстрая сортировка:" +
                " Введите 1\n2 Сортировка деревом: Введите 2");

            byte count = Convert.ToByte(Console.ReadLine());
            string rezult = null;

            if(count == 1)                  //Соритровка дееровм
            {
                Console.WriteLine("Сортировка деревом");
                var arr = inputString.ToCharArray().ToList();
                arr.Sort();
                rezult = new string(arr.ToArray());
            }



            return rezult;
        }




        public static string StringRevers(string PullString)
        {
            var CharArr = new List<char>(PullString.ToCharArray());

            if (PullString.Length % 2 == 0)                     //Чётное количество
            {                                               
                string litter_info = String.Empty;

                var arr = new List<char>(PullString.ToCharArray().Reverse());

                int len = (PullString.Length / 2);
                string Furst_part = new string(arr.ToArray()).Substring(len);
                string Last_part = new string(arr.ToArray()).Substring(0, len);
                string rezult = Furst_part + Last_part;
                var counts = rezult.GroupBy(item => item).Select(grp => new
                {
                    Number = grp.Key,
                    Count = grp.Count()
                });

                arr.Clear();
                arr.AddRange(rezult);        // 1 2 3 4 5 6 7 8 9
                                             //   2     5   7

                int el1 = 0;
                int el2 = 0;
                bool haveEl1 = false;
                bool haveEl2 = false;

                for (int i = 0; i < arr.Count; i++)
                {

                    for (int j = 0; j < vowelLetters.Count; j++)    //asd asd asd asd
                    {                                                      //0123456789
                        if (arr[i] == vowelLetters[j] && haveEl1 == false)
                        {
                                el1 = i;
                                haveEl1 = true;
                        }
                        if (arr[(arr.Count - 1) - i] == vowelLetters[j] && haveEl2 == false)
                        {
                                el2 = (arr.Count-1) - i;
                                haveEl2 = true;
                        }

                        if (haveEl1 == true && haveEl2 == true)
                            break;
                    }

                    if(haveEl1 == true && haveEl2 == true)
                        break;

                }

                string rezSortString = new string(arr.ToArray()).Substring(el1, (el2 - el1)+1);
                string SortSting = OptionSort(rezSortString);

                foreach (var group in counts)
                    litter_info = litter_info + $"Символ = {group.Number}," +
                        $" повторяется {group.Count} раз.\n";



                rezult = $"{rezult}\n{litter_info}";

                rezult = $"\n{rezult}\nСтрока из задания 4 = {rezSortString}\nСтрочька из задания 5 = {SortSting}";

                return rezult;
            }

            //--------------------------------------------------------------------------------------------

            else                                           //Не чётное количиство
            {                                              //переварачивет + оирг
                string litter_info = String.Empty;
                var arr = new List<char>(PullString.ToCharArray().Reverse());
                string Furst_part = new string(arr.ToArray());
                string rezult = Furst_part + PullString;
                var counts = rezult.GroupBy(item => item)
                .Select(grp => new
                {
                    Number = grp.Key,
                    Count = grp.Count()
                });

                arr.Clear();
                arr.AddRange(rezult);

                int el1 = 0;
                int el2 = 0;
                bool haveEl1 = false;
                bool haveEl2 = false;

                for (int i = 0; i < arr.Count; i++)
                {

                    for (int j = 0; j < vowelLetters.Count; j++)    //ddaeddaedd
                    {                                                      //0123456789
                        if (arr[i] == vowelLetters[j] && haveEl1 == false)
                        {
                            el1 = i;
                            haveEl1 = true;
                        }
                        if (arr[(arr.Count - 1) - i] == vowelLetters[j] && haveEl2 == false)
                        {
                            el2 = (arr.Count - 1) - i;
                            haveEl2 = true;
                        }

                        if (haveEl1 == true && haveEl2 == true)
                            break;
                    }

                    if (haveEl1 == true && haveEl2 == true)
                        break;

                }

                //--------------------------------------------------------------------------------

                string rezSortString = new string(arr.ToArray()).Substring(el1, el2 - el1);

                foreach (var group in counts)
                    litter_info = litter_info + $"Символ = {group.Number}, повторяется {group.Count} раз.\n";

                rezult = $"{rezult}\n{litter_info}";

                rezult = $"\n{rezult}\nСтрока из задания 4 = {rezSortString}";

                return rezult;
            }
        }


        //-------------------------------------------------------------------------------------------------


        static void Main(string[] args)
        {
            string string1 = Console.ReadLine();
            Console.WriteLine(CheckStr(ref string1));
            Console.ReadLine();
        }
    }
}
