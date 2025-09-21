using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models.Parties;
using Service.Specifications;
using ServiceAbstraction;
using Shared;
using Shared.DataTransferObjects.WarehouseDtos.PartiesDtos;

namespace Service
{
	public class PartyService(IUnitOfWork unitOfWork, IMapper mapper) : IPartyService
	{
		public async Task<PaginatedResult<ViewReceiptDto>> GetCustomerReceipts(string customerId)
		{
			if (customerId is null)
			{
				throw new ArgumentNullException(nameof(customerId), "The customer Id Couldn't be null");
			}
			var spec = new ReceiptSpecification(customerId);
			var payments = await unitOfWork.GetRepository<Receipt>().GetAllAsync(spec);
			var totalReceipts = await unitOfWork.GetRepository<Receipt>().CountAsync(spec);
			var receiptDtos = mapper.Map<IEnumerable<ViewReceiptDto>>(payments);
			return new PaginatedResult<ViewReceiptDto>(1, receiptDtos.Count(), totalReceipts, receiptDtos);
		}

		public async Task<PaginatedResult<ViewPaymentDto>> GetSupplierPayments(string supplierId)
		{
			if (supplierId is null)
			{
				throw new ArgumentNullException(nameof(supplierId), "The customer Id Couldn't be null");
			}
			var spec = new PaymentSpecification(supplierId);
			var payments = await unitOfWork.GetRepository<Payment>().GetAllAsync(spec);
			var totalPayments = await unitOfWork.GetRepository<Payment>().CountAsync(spec);
			var receiptDtos = mapper.Map<IEnumerable<ViewPaymentDto>>(payments);
			return new PaginatedResult<ViewPaymentDto>(1, receiptDtos.Count(), totalPayments, receiptDtos);
		}
	}
}
