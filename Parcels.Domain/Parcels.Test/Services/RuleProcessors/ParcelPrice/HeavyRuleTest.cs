namespace Parcels.Test.Services.RuleProcessors.ParcelPrice
{
	using Application.Models.Shipment;
	using Application.Services.RuleProcessors.ParcelWeight;
	using FakeItEasy;
	using FluentAssertions;
	using Xunit;

	public class HeavyRuleTest
	{

		[Theory]
		[InlineData(10f, false)]
		[InlineData(10.000001f, true)]
		[InlineData(float.MaxValue, true)]
		public void HeavyRule_ShouldApply_OnlyToValidCases(float weight, bool expectedResult)
		{
			//Arrange
			var dummyParcel = A.Dummy<Parcel>();
			dummyParcel.Weight = weight;

			var rule = new HeavyRule();

			//Act
			var result = rule.IsApplicable(dummyParcel);

			//Assert
			result.Should().Be(expectedResult);
		}
	}
}