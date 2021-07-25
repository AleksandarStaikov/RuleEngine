namespace Parcels.Test.Services.RuleProcessors.ParcelPrice
{
	using Application.Models.Shipment;
	using Application.Services.RuleProcessors.ParcelWeight;
	using FakeItEasy;
	using FluentAssertions;
	using Xunit;

	public class RegularRuleTest
	{
		[Theory]
		[InlineData(1f, false)]
		[InlineData(1.000001f, true)]
		[InlineData(10f, true)]
		[InlineData(10.000001f, false)]
		public void RegularRule_ShouldApply_OnlyToValidCases(float weight, bool expectedResult)
		{
			//Arrange
			var dummyParcel = A.Dummy<Parcel>();
			dummyParcel.Weight = weight;

			var rule = new RegularRule();

			//Act
			var result = rule.IsApplicable(dummyParcel);

			//Assert
			result.Should().Be(expectedResult);
		}
	}
}
