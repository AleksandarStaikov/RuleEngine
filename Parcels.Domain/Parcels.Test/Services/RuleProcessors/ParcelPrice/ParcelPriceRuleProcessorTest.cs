namespace Parcels.Test.Services.RuleProcessors.ParcelPrice
{
	using Application.Models.Shipment;
	using Application.Services.RuleProcessors.ParcelPrice;
	using Application.Services.RuleProcessors.ParcelPrice.Interfaces;
	using FakeItEasy;
	using FluentAssertions;
	using Xunit;

	public class ParcelPriceRuleProcessorTest
	{
		[Fact]
		public void PriceRuleProcessor_Should_LookForFirstApplicableRule()
		{
			//Arrange
			var rule = A.Fake<IPriceProcessingRule>();

			A
				.CallTo(() => rule.IsApplicable(A<Parcel>.Ignored))
				.Returns(true);

			var priceProcessor = new ParcelPriceRuleProcessor(new[] { rule });

			//Act
			priceProcessor.Process(A.Dummy<Parcel>());

			//Assert
			A.CallTo(() => rule.IsApplicable(A<Parcel>.Ignored)).MustHaveHappenedOnceExactly();
			A.CallTo(() => rule.Apply(A<Parcel>.Ignored)).MustHaveHappenedOnceExactly();
		}

		[Fact]
		public void PriceProcessor_WithNoMatchingRule_ShouldReturnNull()
		{
			//Arrange
			var rule = A.Fake<IPriceProcessingRule>();

			A
				.CallTo(() => rule.IsApplicable(A<Parcel>.Ignored))
				.Returns(false);

			var priceProcessor = new ParcelPriceRuleProcessor(new[] { rule });

			//Act
			var result = priceProcessor.Process(A.Dummy<Parcel>());

			//Assert
			A.CallTo(() => rule.IsApplicable(A<Parcel>.Ignored)).MustHaveHappenedOnceExactly();
			A.CallTo(() => rule.Apply(A<Parcel>.Ignored)).MustNotHaveHappened();
			result.Should().BeNull();
		}

		[Fact]
		public void PriceRuleProcessor_ShouldReturn_TheValueOftheRuleApplied()
		{
			//Arrange
			var ruleA = A.Fake<IPriceProcessingRule>();
			var ruleB = A.Fake<IPriceProcessingRule>();
			var expectedResult = "Processed by mocked department";

			A
				.CallTo(() => ruleA.IsApplicable(A<Parcel>.Ignored))
				.Returns(false);

			A
				.CallTo(() => ruleB.IsApplicable(A<Parcel>.Ignored))
				.Returns(true);

			A
				.CallTo(() => ruleB.Apply(A<Parcel>.Ignored))
				.Returns(expectedResult);

			var priceProcessor = new ParcelPriceRuleProcessor(new[] { ruleA, ruleB });

			//Act
			var result = priceProcessor.Process(A.Dummy<Parcel>());

			//Assert
			result.ProcessingResult.Should().Be(expectedResult);
		}
	}
}
