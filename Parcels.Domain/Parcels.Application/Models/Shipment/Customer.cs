namespace Parcels.Application.Models.Shipment
{
	using System.Xml.Serialization;

	[XmlType("Company")]
	public class Customer
	{
		public Address Address { get; set; }
		public string Name { get; set; }
	}
}