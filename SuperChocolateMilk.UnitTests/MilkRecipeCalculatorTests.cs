namespace SuperChocolateMilk.UnitTests;

using Xunit;
using SuperChocolateMilk.Core;

public class MilkRecipeCalculatorTests
{
    [Fact]
    public void CalculateChocolateSyrup_RegularRichness_ReturnsTenPercentRatio()
    {
        // 1. ARRANGE: Set up the inputs and expected conditions
        int milkVolume = 1000;
        string richness = "REGULAR";

        // 2. ACT: Call the method we are testing
        decimal result = MilkRecipeCalculator.CalculateChocolateSyrupRequired(milkVolume, richness);

        // 3. ASSERT: Check if the actual result matches our expected output
        Assert.Equal(100m, result);
    }

    [Theory]
    [InlineData(1000, "LIGHT", 75)]        // 1000ml * 10% * 0.75 = 75ml
    [InlineData(1000, "EXTRA", 150)]       // 1000ml * 10% * 1.50 = 150ml
    [InlineData(1000, "ULTRA_CHOCO", 200)] // 1000ml * 10% * 2.00 = 200ml
    [InlineData(0, "REGULAR", 0)]          // 0ml milk should return 0ml syrup
    public void CalculateChocolateSyrup_VariousScenarios_ReturnsExpectedAmount(
        int milkVolume, string richness, decimal expectedSyrup)
    {
        // Act: Execute using the parameters passed from [InlineData]
        decimal actualResult = MilkRecipeCalculator.CalculateChocolateSyrupRequired(milkVolume, richness);

        // Assert: Verify actual matches expected for each row
        Assert.Equal(expectedSyrup, actualResult);
    }
}