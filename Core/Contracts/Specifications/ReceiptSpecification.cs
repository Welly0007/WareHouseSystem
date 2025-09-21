using DomainLayer.Contracts;
using DomainLayer.Models.Parties;

namespace Service.Specifications
{
	public class ReceiptSpecification : AbsSpecification<Receipt>
	{
		public ReceiptSpecification(string CustomerId)
		{
			Criteria = p => p.CustomerId == CustomerId;
			Includes.Add(p => p.Customer);
		}
	}
}