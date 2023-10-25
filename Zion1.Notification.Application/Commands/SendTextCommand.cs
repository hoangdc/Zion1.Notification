using MediatR;
using Zion1.Notification.Application.Mapper;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;
using Zion1.Notification.Share.DTOs;

namespace Zion1.Notification.Application.Commands
{
    public class SendTextCommand : TextDto, IRequest<int>
    {
        public class SendTextCommandHandler : IRequestHandler<SendTextCommand, int>
        {
            private readonly ITextCommandRepository _textRepository;
            public SendTextCommandHandler(ITextCommandRepository textRepository)
            {
                _textRepository = textRepository;
            }
            public async Task<int> Handle(SendTextCommand command, CancellationToken cancellationToken)
            {
                var text = NotificationMapper.Mapper.Map<Text>(command);
                var isSuccess = await _textRepository.SendTextAsync(text);
                if (isSuccess)
                {
                    return await _textRepository.SaveTextAsync(text);
                }
                return 0;
            }
        }
    }
}
