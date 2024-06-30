using Newtonsoft.Json;
using static Task_API.Models.AppSetingsOption;

namespace Task_API.DAT
{
    static public class kostil   // я без понятия как это назвать
    {
        static AppSettings appSettings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(@"./appsettings.json"));
        public static string ApiOption_GetRandom()
        {
            return appSettings.Random_api;
        }

        public static List<string> ApiOption_GetBlackList()
        {
            return appSettings.BlackList;
        }
    }
}
