using AutoMapper;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class NotificationMapping:Profile
    {
        public NotificationMapping()
        {
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<About, CreateNotificationDto>().ReverseMap();
            CreateMap<About, UpdateNotificationDto>().ReverseMap();
        }
    }
}
