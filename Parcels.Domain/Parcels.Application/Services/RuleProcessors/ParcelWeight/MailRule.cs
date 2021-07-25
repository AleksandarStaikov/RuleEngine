namespace Parcels.Application.Services.RuleProcessors.ParcelWeight
{
	using Interfaces;
	using Models.Shipment;

	public class MailRule : IWeightProcessingRule
	{
		private const float MinWeight = 0;
		private const float MaxWeight = 1;

		public bool IsApplicable(Parcel parcel)
		{
			var passesLowerThreshold = parcel.Weight >= MinWeight;
			var passesUpperThreshold = parcel.Weight <= MaxWeight;

			return passesUpperThreshold && passesLowerThreshold;
		}

		public string Apply(Parcel parcel)
		{
			//Here is the place for the super complex processing logic

			return "Mail department";
		}
	}
}