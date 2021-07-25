namespace Parcels.Test
{
	using Application.Services.RuleProcessors;
	using Application.Services.RuleProcessors.ParcelPrice;
	using Application.Services.RuleProcessors.ParcelPrice.Interfaces;
	using Application.Services.RuleProcessors.ParcelWeight;
	using Application.Services.RuleProcessors.ParcelWeight.Interfaces;
	using FluentAssertions;
	using Microsoft.Extensions.DependencyInjection;
	using Xunit;

	public class ApplicationConfigurationTest
	{
		[Fact]
		public void ApplicationConfiguration_ShouldRegister_WeightProcessor()
		{
			//Arrange
			var serviceProvider = TestHelper.GetServiceProvider();

			//Act
			var service = serviceProvider.GetService(typeof(IRuleProcessor<IWeightProcessingRule>));

			//Assert
			service.Should().NotBeNull();
		}

		[Fact]
		public void ApplicationConfiguration_ShouldRegister_MailRule()
		{
			//Arrange
			var serviceProvider = TestHelper.GetServiceProvider();

			//Act
			var services = serviceProvider.GetServices(typeof(IWeightProcessingRule));

			//Assert
			services.Should().Contain(x => x is MailRule);
		}

		[Fact]
		public void ApplicationConfiguration_ShouldRegister_RegularRule()
		{
			//Arrange
			var serviceProvider = TestHelper.GetServiceProvider();

			//Act
			var services = serviceProvider.GetServices(typeof(IWeightProcessingRule));

			//Assert
			services.Should().Contain(x => x is RegularRule);
		}

		[Fact]
		public void ApplicationConfiguration_ShouldRegister_HeavyRule()
		{
			//Arrange
			var serviceProvider = TestHelper.GetServiceProvider();

			//Act
			var services = serviceProvider.GetServices(typeof(IWeightProcessingRule));

			//Assert
			services.Should().Contain(x => x is HeavyRule);
		}

		[Fact]
		public void ApplicationConfiguration_ShouldRegister_PriceProcessor()
		{
			//Arrange
			var serviceProvider = TestHelper.GetServiceProvider();

			//Act
			var service = serviceProvider.GetService(typeof(IRuleProcessor<IPriceProcessingRule>));

			//Assert
			service.Should().NotBeNull();
		}

		[Fact]
		public void ApplicationConfiguration_ShouldRegister_InsuranceRule()
		{
			//Arrange
			var serviceProvider = TestHelper.GetServiceProvider();

			//Act
			var services = serviceProvider.GetServices(typeof(IPriceProcessingRule));

			//Assert
			services.Should().Contain(x => x is InsuranceRule);
		}
	}
}
