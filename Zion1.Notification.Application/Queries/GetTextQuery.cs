using MediatR;
using Zion1.Notification.Application.Mapper;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Share.DTOs;

namespace Zion1.Notification.Application.Queries
{
    public class GetTextQuery : IRequest<IReadOnlyList<TextDto>>
    {
        public class GetTextQueryHandler : IRequestHandler<GetTextQuery, IReadOnlyList<TextDto>>
        {
            private readonly ITextQueryRepository _TextRepository;
            public GetTextQueryHandler(ITextQueryRepository TextRepository)
            {
                _TextRepository = TextRepository;
            }
            

            public async Task<IReadOnlyList<TextDto>> Handle(GetTextQuery request, CancellationToken cancellationToken)
            {
                var textList = await _TextRepository.GetAllAsync();
                return NotificationMapper.Mapper.Map<IReadOnlyList<TextDto>>(textList);
            }
            
        }
    }
}
