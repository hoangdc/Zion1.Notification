using Microsoft.AspNetCore.Mvc;
using Zion1.Common.API.Controller;
using Zion1.Notification.Application.Commands;
using Zion1.Notification.Application.Queries;
using Zion1.Notification.Share.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zion1.Notification.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : CoreController
    {
        [HttpPost]
        public async Task<int> SendEmail(SendEmailCommand sendEmailCommand)
        {
            return await Mediator.Send(sendEmailCommand);
        }

        [HttpGet]
        public async Task<IReadOnlyList<EmailDto>> GetEmail()
        {
            return await Mediator.Send(new GetEmailQuery());
        }
    }
}
