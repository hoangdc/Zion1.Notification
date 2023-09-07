using Microsoft.AspNetCore.Mvc;
using Zion1.Common.API.Controller;
using Zion1.Notification.Application.Commands;
using Zion1.Notification.Application.Queries;
using Zion1.Notification.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zion1.Notification.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : CoreController
    {
        [HttpPost(Name = "SendText")]
        public async Task<bool> SendText(SendTextCommand sendTextCommand)
        {
            return await Mediator.Send(sendTextCommand);
        }

        [HttpGet(Name = "GetText")]
        public async Task<IReadOnlyList<Text>> GetText()
        {
            return await Mediator.Send(new GetTextQuery());
        }
    }
}
