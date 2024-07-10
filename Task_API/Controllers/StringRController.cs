using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Xml.Linq;
using Task_API.DAT;
using Task_API.Models;
using Task_API.Services;
using static Task_API.Models.AppSetingsOption;



namespace Task_API.Controllers;
[ApiController]
[Microsoft.AspNetCore.Mvc.Route("[controller]")]
public class StringRController : ControllerBase
{
    
    [HttpGet]
    public ActionResult GetString(string str, int Option_sort) 
    {

        var EngLitter = new List<char> { 'a', 'b', 'c', 'd', 'e',
                'f', 'g', 'h', 'i','j', 'k',
                'l', 'm', 'n', 'o', 'p', 'q',
                'r', 's', 't', 'u', 'v', 'w',
                'x', 'y', 'z'
        };     //очень не крассиво переделай

        var CharArr = new List<char>(str.ToCharArray());
        
        int qua_lit = CharArr.Except(EngLitter).Count();

        var BlackList = kostil.ApiOption_GetBlackList();

        StringR stringR = new StringR();
        stringR.OtvString = StringRService.CheckStr(ref str, Option_sort);

        if (BlackList.Any(str.Contains))
        {
            return BadRequest(new { Error = stringR.OtvString });
        }

        if (qua_lit > 0)
            return BadRequest(new { Error = stringR.OtvString });

        else
            return Ok(new { stringR.OtvString });
    }
}

