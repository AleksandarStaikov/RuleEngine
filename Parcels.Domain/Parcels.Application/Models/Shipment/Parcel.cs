namespace Parcels.Application.Models.Shipment
{
	public class Parcel
	{
		public Customer Sender { get; set; }
		public Customer Receipient { get; set; }
		public float Weight { get; set; }
		public decimal Value { get; set; }
	}
}