using MediatR;
using Zion1.Notification.Application.Mapper;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;
using Zion1.Notification.Share.DTOs;

namespace Zion1.Notification.Application.Commands
{
    public class SendEmailCommand : EmailDto, IRequest<int>
    {
        public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, int>
        {
            private readonly IEmailCommandRepository _emailRepository;
            public SendEmailCommandHandler(IEmailCommandRepository emailRepository)
            {
                _emailRepository = emailRepository;
            }
            public async Task<int> Handle(SendEmailCommand command, CancellationToken cancellationToken)
            {
                var email = NotificationMapper.Mapper.Map<Email>(command);
                return await _emailRepository.SendAsync(email);
            }
        }
    }
}
