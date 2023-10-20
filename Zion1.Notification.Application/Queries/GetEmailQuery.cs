using MediatR;
using Zion1.Notification.Application.Mapper;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Share.DTOs;

namespace Zion1.Notification.Application.Queries
{
    public class GetEmailQuery : IRequest<IReadOnlyList<EmailDto>>
    {
        public class GetAllEmailsQueryHandler : IRequestHandler<GetEmailQuery, IReadOnlyList<EmailDto>>
        {
            private readonly IEmailQueryRepository _emailRepository;
            public GetAllEmailsQueryHandler(IEmailQueryRepository emailRepository)
            {
                _emailRepository = emailRepository;
            }
            

            public async Task<IReadOnlyList<EmailDto>> Handle(GetEmailQuery request, CancellationToken cancellationToken)
            {
                var emailList = await _emailRepository.GetAllAsync();
                return NotificationMapper.Mapper.Map<IReadOnlyList<EmailDto>>(emailList);
            }
            
        }
    }
}
