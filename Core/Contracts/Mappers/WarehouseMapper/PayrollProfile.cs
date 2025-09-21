using AutoMapper;
using DomainLayer.Models.WarehouseModule;
using Shared.DataTransferObjects.WarehouseDtos.WarehouseModuleDtos.Crud;

namespace Service.Mappers.WarehouseMapper
{
	public class PayrollProfile : Profile
	{
		public PayrollProfile()
		{
			CreateMap<CreatePayrollDto, Payroll>();
			CreateMap<Payroll, ViewPayrollDto>();
		}
	}
}