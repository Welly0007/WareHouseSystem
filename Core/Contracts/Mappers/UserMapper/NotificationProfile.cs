using AutoMapper;
using DomainLayer.Models.UserModule;
using Shared.DataTransferObjects.WarehouseDtos.UserModuleDtos;

namespace Service.Mappers.UserMapper
{
	public class NotificationProfile : Profile
	{
		public NotificationProfile()
		{
			CreateMap<CreateNotificationDto, Notification>();
			CreateMap<Notification, ViewNotificationDto>();
		}
	}
}