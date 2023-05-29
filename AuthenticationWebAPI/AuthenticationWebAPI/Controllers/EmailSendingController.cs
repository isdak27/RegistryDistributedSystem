using AuthenticationWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using System.Net.Http;

namespace AuthenticationWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailSendingController : ControllerBase

    {
        
        [HttpGet(Name = "GetRegistryData")]
        public void getRegsitry(User user)
        {


        }
    }
   
}
