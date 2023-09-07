using MediatR;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Application.Queries
{
    public class GetTextQuery : IRequest<IReadOnlyList<Text>>
    {
        public class GetTextQueryHandler : IRequestHandler<GetTextQuery, IReadOnlyList<Text>>
        {
            private readonly ITextQueryRepository _TextRepository;
            public GetTextQueryHandler(ITextQueryRepository TextRepository)
            {
                _TextRepository = TextRepository;
            }
            

            public async Task<IReadOnlyList<Text>> Handle(GetTextQuery request, CancellationToken cancellationToken)
            {
                return await _TextRepository.GetAllAsync();
            }
            
        }
    }
}
