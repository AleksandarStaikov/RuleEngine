namespace Parcels.Application.Services.RuleProcessors
{
	using Models;
	using Models.Shipment;

	public interface IRuleProcessor<T>
		where T : IRule
	{
		ParcelProcessingResult Process(Parcel parcel);
	}
}
