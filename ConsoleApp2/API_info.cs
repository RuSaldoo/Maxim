using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleApp2;

namespace ConsoleApp2
{
    static public class API_info
    {
        static public int api_get_info(int Leng_string)
        {
            string max_str_inf = Leng_string.ToString();
            string Url = $"http://www.randomnumberapi.com/api/v1.0/random?min=0&max={max_str_inf}&count=1";
            string response;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream())) 
            {
                response = streamReader.ReadToEnd();
            }
            int value;
            int.TryParse(string.Join("", response.Where(c => char.IsDigit(c))),out value);
            return value;
        }
    }
}
