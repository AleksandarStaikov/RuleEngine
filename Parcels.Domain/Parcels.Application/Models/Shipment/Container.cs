namespace Parcels.Application.Models.Shipment
{
	using System;
	using System.Collections.Generic;
	using System.Xml.Serialization;

	public class Container
	{
		public string Id { get; set; }
		public DateTime ShippingDate { get; set; }
		[XmlArray("parcels")]
		public List<Parcel> Parcels { get; set; }
	}
}
