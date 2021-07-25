namespace Parcels.Application.Services.RuleProcessors.ParcelWeight
{
	using Interfaces;
	using Models;
	using Models.Shipment;
	using System.Collections.Generic;
	using System.Linq;

	public class ParcelWeightRuleProcessor : IRuleProcessor<IWeightProcessingRule>
	{
		private readonly IList<IWeightProcessingRule> _rules;

		public ParcelWeightRuleProcessor(IWeightProcessingRule[] rules)
		{
			_rules = rules.ToList();
		}

		public ParcelProcessingResult Process(Parcel parcel)
		{
			var rule = _rules.FirstOrDefault(x => x.IsApplicable(parcel));

			if (rule == null)
			{
				return null;
			}

			var processingResult = new ParcelProcessingResult()
			{
				Parcel = parcel,
				ProcessingResult = rule.Apply(parcel)
			};
			
			return processingResult;
		}
	}
}
