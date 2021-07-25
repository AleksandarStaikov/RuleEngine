namespace Parcels.Application.Models
{
	using System.Collections.Generic;
	using Shipment;

	public class ParcelProcessingResult
	{
		public string ProcessingResult { get; set; }
		public Parcel Parcel { get; set; }
	}
}
