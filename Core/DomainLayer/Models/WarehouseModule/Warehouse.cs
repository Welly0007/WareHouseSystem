namespace DomainLayer.Models
{
	public class Warehouse : BaseEntity
	{
		public string Name { get; set; } = null!;
		public string Location { get; set; } = null!;
		public string Description { get; set; } = null!;
	}
}
