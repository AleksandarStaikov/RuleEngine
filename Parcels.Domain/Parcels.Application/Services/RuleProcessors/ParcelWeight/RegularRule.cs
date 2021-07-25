namespace Parcels.Application.Services.RuleProcessors.ParcelWeight
{
	using Interfaces;
	using Models.Shipment;

	public class RegularRule : IWeightProcessingRule
	{
		private const float MinWeight = 1;
		private const float MaxWeight = 10;

		public bool IsApplicable(Parcel parcel)
		{
			var passesLowerThreshold = parcel.Weight > MinWeight;
			var passesUpperThreshold = parcel.Weight <= MaxWeight;

			return passesUpperThreshold && passesLowerThreshold;
		}

		public string Apply(Parcel parcel)
		{
			//Here is the place for the super complex processing logic

			return "Regular department";
		}
	}
}