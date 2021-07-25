namespace Parcels.Application.Services.RuleProcessors
{
	using Models.Shipment;

	public interface IRule
	{
		bool IsApplicable(Parcel parcel);
		string Apply(Parcel parcel);
	}
}
