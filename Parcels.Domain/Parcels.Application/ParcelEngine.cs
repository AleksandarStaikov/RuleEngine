namespace Parcels.Application
{
	using Models;
	using Models.Shipment;
	using Services.FileHandling.Interfaces;
	using Services.RuleProcessors;
	using Services.RuleProcessors.ParcelPrice.Interfaces;
	using Services.RuleProcessors.ParcelWeight.Interfaces;
	using System.Collections.Generic;

	public class ParcelEngine : IParcelEngine
	{
		private readonly IFileHandler _fileHandler;
		private readonly IXmlParsers _xmlParsers;
		private readonly IRuleProcessor<IWeightProcessingRule> _weightProcessor;
		private readonly IRuleProcessor<IPriceProcessingRule> _priceProcessor;

		public ParcelEngine(IFileHandler fileHandler,
			IXmlParsers xmlParsers,
			IRuleProcessor<IWeightProcessingRule> weightProcessor,
			IRuleProcessor<IPriceProcessingRule> priceProcessor)
		{
			_fileHandler = fileHandler;
			_xmlParsers = xmlParsers;
			_weightProcessor = weightProcessor;
			_priceProcessor = priceProcessor;
		}

		public List<ParcelProcessingResult> ProcessParcels(string fileName)
		{
			var fileLocation = _fileHandler.SplitFilePath(fileName);

			_fileHandler.ValidateDirectoryExists(fileLocation);
			_fileHandler.ValidateFileExists(fileLocation);

			var containerData = _xmlParsers.DeserializeToObject<Container>(fileLocation.FullPath);

			var parcelProcessingResults = RunParcelRuleEngine(containerData);

			return parcelProcessingResults;
		}

		public List<ParcelProcessingResult> RunParcelRuleEngine(Container containerData)
		{
			var parcelProcessingResults = new List<ParcelProcessingResult>();

			foreach (var parcel in containerData.Parcels)
			{
				var weightProcessingResult = _weightProcessor.Process(parcel);
				if (weightProcessingResult != null)
				{
					parcelProcessingResults.Add(weightProcessingResult);
				}

				var priceProcessingResult = _priceProcessor.Process(parcel);
				if (priceProcessingResult != null)
				{
					parcelProcessingResults.Add(priceProcessingResult);
				}
			}

			return parcelProcessingResults;
		}
	}
}
