using MediatR;
using Zion1.Notification.Application.Mapper;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Application.Commands
{
    public class SendTextCommand : Text, IRequest<bool>
    {
        public class SendTextCommandHandler : IRequestHandler<SendTextCommand, bool>
        {
            private readonly ITextCommandRepository _textRepository;
            public SendTextCommandHandler(ITextCommandRepository textRepository)
            {
                _textRepository = textRepository;
            }
            public async Task<bool> Handle(SendTextCommand command, CancellationToken cancellationToken)
            {
                var textEntity = NotificationMapper.Mapper.Map<Text>(command);
                if (textEntity is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                var isSuccess = await _textRepository.SendAsync(textEntity);
                
                return isSuccess;

            }
        }
    }
}
