using DomainLayer.Contracts;
using DomainLayer.Models.WarehouseModule;

namespace Service.Specifications
{
	public class DefectiveSpecification : AbsSpecification<DefectiveReport>
	{
		public DefectiveSpecification(string ProductId)
		{
			Criteria = p => p.ProductId == ProductId;
		}
	}
}