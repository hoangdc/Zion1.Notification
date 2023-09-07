using MediatR;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Application.Queries
{
    public class GetEmailQuery : IRequest<IReadOnlyList<Email>>
    {
        public class GetAllEmailsQueryHandler : IRequestHandler<GetEmailQuery, IReadOnlyList<Email>>
        {
            private readonly IEmailQueryRepository _emailRepository;
            public GetAllEmailsQueryHandler(IEmailQueryRepository emailRepository)
            {
                _emailRepository = emailRepository;
            }
            

            public async Task<IReadOnlyList<Email>> Handle(GetEmailQuery request, CancellationToken cancellationToken)
            {
                return await _emailRepository.GetAllAsync();
            }
            
        }
    }
}
