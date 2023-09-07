using AutoMapper;
using Zion1.Common.Application.Mapper;
using Zion1.Notification.Application.Commands;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Application.Mapper
{
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Email, SendEmailCommand>().ReverseMap();
            CreateMap<Text, SendTextCommand>().ReverseMap();
        }
    }

    public class NotificationMapper : CommonMapper<NotificationMappingProfile>
    {

    }
}
