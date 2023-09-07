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
    public class EmailController : CoreController
    {
        [HttpPost(Name = "SendEmail")]
        public async Task<bool> SendEmail(SendEmailCommand sendEmailCommand)
        {
            return await Mediator.Send(sendEmailCommand);
        }

        [HttpGet(Name = "GetEmail")]
        public async Task<IReadOnlyList<Email>> GetEmail()
        {
            return await Mediator.Send(new GetEmailQuery());
        }
    }
}
