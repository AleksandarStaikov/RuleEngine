namespace Parcels.Application
{
	using Microsoft.Extensions.DependencyInjection;
	using Services.FileHandling;
	using Services.FileHandling.Interfaces;
	using Services.RuleProcessors;
	using System;
	using System.Linq;

	public static class ApplicationConfiguration
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
			=> services
				.AddRuleProcessors()
				.AddTransient<IFileHandler, FileHandler>()
				.AddTransient<IXmlParsers, XmlParsers>()
				.AddTransient<IParcelEngine, ParcelEngine>();

		private static IServiceCollection AddRuleProcessors(this IServiceCollection services)
		{
			var processorInterfaces = typeof(IRuleProcessor<>);

			var assemblyTypes = processorInterfaces
				.Assembly
				.GetTypes();

			var processorTypes = assemblyTypes
				.Where(x => x
					.GetInterfaces()
					.Any(y => y.IsGenericType &&
					          y.GetGenericTypeDefinition() == processorInterfaces))
				.ToList();

			foreach (var processorType in processorTypes)
			{
				var interfaceWithParameter = processorType.GetInterface(processorInterfaces.Name);

				var processorRuleInterface = interfaceWithParameter.GetGenericArguments().First();

				var processorRules = assemblyTypes
					.Where(x => processorRuleInterface.IsAssignableFrom(x) && !x.IsInterface)
					.ToList();

				foreach (var processingRuleType in processorRules)
				{
					services.AddTransient(processorRuleInterface, processingRuleType);
				}

				services.AddTransient(interfaceWithParameter, (serviceProvider) =>
				{
					var rules = serviceProvider.GetServices(processorRuleInterface);
					var processorInstance = Activator.CreateInstance(processorType, rules);
					return processorInstance;
				});
			}
			
			return services;
		}
	}
}
