namespace Parcels.Test.Services.RuleProcessors.ParcelWeight
{
	using Application.Models.Shipment;
	using Application.Services.RuleProcessors.ParcelPrice;
	using FakeItEasy;
	using FluentAssertions;
	using Xunit;

	public class InsuranceRuleTest
	{
		[Theory]
		[InlineData(1000d, false)]
		[InlineData(1000.000001d, true)]
		[InlineData(99932492349.1231, true)]
		public void HeavyRule_ShouldApply_OnlyToValidCases(decimal price, bool expectedResult)
		{
			//Arrange
			var dummyParcel = A.Dummy<Parcel>();
			dummyParcel.Value = price;

			var rule = new InsuranceRule();

			//Act
			var result = rule.IsApplicable(dummyParcel);

			//Assert
			result.Should().Be(expectedResult);
		}
	}
}