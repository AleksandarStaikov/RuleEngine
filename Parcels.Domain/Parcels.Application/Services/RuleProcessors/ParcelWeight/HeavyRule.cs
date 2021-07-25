namespace Parcels.Application.Services.RuleProcessors.ParcelWeight
{
	using Interfaces;
	using Models.Shipment;

	public class HeavyRule : IWeightProcessingRule
	{
		private const float MinWeight = 10;

		public bool IsApplicable(Parcel parcel)
		{
			var passesLowerThreshold = parcel.Weight > MinWeight;

			return passesLowerThreshold;
		}

		public string Apply(Parcel parcel)
		{
			//Here is the place for the super complex processing logic

			return "Heavy department";
		}
	}
}