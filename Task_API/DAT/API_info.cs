using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task_API.Models;
using static System.Net.Mime.MediaTypeNames;
using static Task_API.Models.AppSetingsOption;

namespace Task_API.DAT
{
    static public class API_info
    {
        static public int api_get_info(int Leng_string)
        {
            string url = kostil.ApiOption_GetRandom();

            string max_str_inf = Leng_string.ToString();
            string pattern = @"max=\s*(\w+)";

            url = Regex.Replace(url, pattern, $"max={max_str_inf}");


            string response;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
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
