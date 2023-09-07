using MediatR;
using Zion1.Notification.Application.Mapper;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Application.Commands
{
    public class SendEmailCommand : Email, IRequest<bool>
    {
        public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, bool>
        {
            private readonly IEmailCommandRepository _emailRepository;
            public SendEmailCommandHandler(IEmailCommandRepository emailRepository)
            {
                _emailRepository = emailRepository;
            }
            public async Task<bool> Handle(SendEmailCommand command, CancellationToken cancellationToken)
            {
                var emailEntity = NotificationMapper.Mapper.Map<Email>(command);
                if (emailEntity is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                var isSuccess = await _emailRepository.SendAsync(emailEntity);
                
                return isSuccess;

            }
        }
    }
}
