namespace Parcels.Application.Services.RuleProcessors.ParcelPrice
{
	using Interfaces;
	using Models.Shipment;

	public class InsuranceRule : IPriceProcessingRule
	{
		private const decimal MinPriceThreshold = 1000;

		public bool IsApplicable(Parcel parcel)
		{
			var passesLowerThreshold = parcel.Value > MinPriceThreshold;

			return passesLowerThreshold;
		}

		public string Apply(Parcel parcel)
		{
			return "Insurance department";
		}
	}
}
