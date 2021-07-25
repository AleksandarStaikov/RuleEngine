namespace Parcels.Test.Services.RuleProcessors.ParcelWeight
{
	using Application.Models.Shipment;
	using Application.Services.RuleProcessors.ParcelWeight;
	using Application.Services.RuleProcessors.ParcelWeight.Interfaces;
	using FakeItEasy;
	using FluentAssertions;
	using Xunit;

	public class ParcelWeightRuleProcessorTest
	{
		[Fact]
		public void WeightRuleProcessor_Should_LookForFirstApplicableRule()
		{
			//Arrange
			var rule = A.Fake<IWeightProcessingRule>();

			A
				.CallTo(() => rule.IsApplicable(A<Parcel>.Ignored))
				.Returns(true);

			var weightProcessor = new ParcelWeightRuleProcessor(new [] { rule });

			//Act
			weightProcessor.Process(A.Dummy<Parcel>());

			//Assert
			A.CallTo(() => rule.IsApplicable(A<Parcel>.Ignored)).MustHaveHappenedOnceExactly();
			A.CallTo(() => rule.Apply(A<Parcel>.Ignored)).MustHaveHappenedOnceExactly();
		}

		[Fact]
		public void WeightRuleProcessor_WithNoMatchingRule_ShouldReturnNull()
		{
			//Arrange
			var rule = A.Fake<IWeightProcessingRule>();

			A
				.CallTo(() => rule.IsApplicable(A<Parcel>.Ignored))
				.Returns(false);

			var weightProcessor = new ParcelWeightRuleProcessor(new[] { rule });

			//Act
			var result = weightProcessor.Process(A.Dummy<Parcel>());

			//Assert
			A.CallTo(() => rule.IsApplicable(A<Parcel>.Ignored)).MustHaveHappenedOnceExactly();
			A.CallTo(() => rule.Apply(A<Parcel>.Ignored)).MustNotHaveHappened();
			result.Should().BeNull();
		}

		[Fact]
		public void WeightRuleProcessor_ShouldReturn_TheValueOftheRuleApplied()
		{
			//Arrange
			var ruleA = A.Fake<IWeightProcessingRule>();
			var ruleB = A.Fake<IWeightProcessingRule>();
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

			var weightProcessor = new ParcelWeightRuleProcessor(new[] { ruleA, ruleB });

			//Act
			var result = weightProcessor.Process(A.Dummy<Parcel>());

			//Assert
			result.ProcessingResult.Should().Be(expectedResult);
		}
	}
}
