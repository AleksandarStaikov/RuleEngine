namespace Parcels.Test.Services.RuleProcessors.ParcelPrice
{
	using Application.Models.Shipment;
	using Application.Services.RuleProcessors.ParcelWeight;
	using FakeItEasy;
	using FluentAssertions;
	using Xunit;

	public class MailRuleTest
	{

		[Theory]
		[InlineData(-0.000001f, false)]
		[InlineData(0f, true)]
		[InlineData(1f, true)]
		[InlineData(1.000001f, false)]
		public void MailRule_ShouldApply_OnlyToValidCases(float weight, bool expectedResult)
		{
			//Arrange
			var dummyParcel = A.Dummy<Parcel>();
			dummyParcel.Weight = weight;

			var rule = new MailRule();

			//Act
			var result = rule.IsApplicable(dummyParcel);

			//Assert
			result.Should().Be(expectedResult);
		}
	}
}