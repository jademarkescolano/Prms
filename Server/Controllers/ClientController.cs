using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StarbeeRealty.Server.Services;
using StarbeeRealty.Shared;

namespace StarbeeRealty.Server.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : Controller
    {
        ClientServices xservices;
     
        public ClientController(ClientServices xservices)
        {
            this.xservices = xservices;
         
        }
        //View Clients

        [HttpGet]
        //[Authorize]
        public async Task<List<clients>> Clients()
        {
            var ret = await xservices.Clients();
            return ret;
        }

        [HttpGet]
        //[Authorize]
        public async Task<List<clients>> SearchClient(string search)
        {
            var ret = await xservices.SearchClient(search);
            return ret;
        }

        //Add Client
        [HttpPost]
        //[Authorize]
        public async Task<int> AddClient([FromBody] clients _clients)
        {
            var ret = await xservices.AddClient(_clients);
            return ret;
        }


        [HttpPost]
        //[Authorize]
        public async Task<int> UpdateClient([FromBody] clients _clients)
        {
            var ret = await xservices.UpdateClient(_clients);
            return ret;
        }
    }
}
