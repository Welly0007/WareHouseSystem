using DomainLayer.Contracts;
using DomainLayer.Models.Parties;

namespace Service.Specifications
{
	public class PaymentSpecification : AbsSpecification<Payment>
	{
		public PaymentSpecification(string SupplierId)
		{
			Criteria = p => p.SupplierId == SupplierId;
			Includes.Add(p => p.Supplier);
		}
	}
}