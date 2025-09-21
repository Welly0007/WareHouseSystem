using AutoMapper;
using DomainLayer.Models.WarehouseModule;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Service.Mappers.WarehouseMapper
{
	public class EmployeeProfile : Profile
	{
		public EmployeeProfile()
		{
			CreateMap<CreateEmployeeDto, Employee>();
			CreateMap<Employee, ViewEmployeeDto>();
		}
	}
}