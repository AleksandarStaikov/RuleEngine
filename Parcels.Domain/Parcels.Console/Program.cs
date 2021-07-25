namespace Parcels.Console
{
	using Application;
	using Microsoft.Extensions.DependencyInjection;
	using System;
	using Application.Models;

	class Program
	{
		public static void Main(string[] args)
		{
			var serviceProvider = new ServiceCollection()
				.AddApplication()
				.BuildServiceProvider();

			var parcelEngine = serviceProvider.GetService<IParcelEngine>();

			var parcelsXmlFilePath = "D:\\dev\\NewAssignment\\Container_68465468.xml";

			Console.WriteLine("Where can the XML file be located?");
			Console.WriteLine($"If no path is provided, '{parcelsXmlFilePath}' will be used!");
			var userInput = Console.ReadLine();

			try
			{
				var processResult = parcelEngine.ProcessParcels(string.IsNullOrEmpty(userInput) ? parcelsXmlFilePath : userInput);

				foreach (var parcelProcessingResult in processResult)
				{
					Console.WriteLine($"Parcel from '{parcelProcessingResult.Parcel.Sender.Name}' to '{parcelProcessingResult.Parcel.Receipient.Name}' was processed by the {parcelProcessingResult.ProcessingResult}");
				}
			}
			catch (FeedbackException exception)
			{
				Console.WriteLine(exception.Message);
			}

			Console.ReadLine();
		}
	}
}