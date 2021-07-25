namespace Parcels.Application.Services.RuleProcessors.ParcelPrice
{
	using Interfaces;
	using Models;
	using Models.Shipment;
	using System.Collections.Generic;
	using System.Linq;

	public class ParcelPriceRuleProcessor : IRuleProcessor<IPriceProcessingRule>
	{
		private readonly IList<IPriceProcessingRule> _rules;

		public ParcelPriceRuleProcessor(IList<IPriceProcessingRule> rules)
		{
			_rules = rules;
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
