using AutoMapper;
using DomainLayer.Models.UserModule;
using Shared.DataTransferObjects.UserModuleDto;

namespace Service.Mappers.UserMapper
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<RegisterRequest, User>()
				.ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
			//.ForMember(dest => dest, opt => opt.MapFrom(src => src.Role.ToString()));
			CreateMap<User, UserViewDto>()
				.ForMember(dest => dest.Roles, opt => opt.Ignore());
			//.ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
		}
	}
}
