namespace SuperChocolateMilk.UnitTests;

using Xunit;
using SuperChocolateMilk.Core;

public class RecipeHelpersTests
{
    // 1. CombineVolumes
    [Fact]
    public void CombineVolumes_TwoPositiveVolumes_ReturnsSum()
    {
        int volumeA = 300;
        int volumeB = 200;

        int result = RecipeHelpers.CombineVolumes(volumeA, volumeB);

        Assert.Equal(500, result);
    }

    // 2. LitersToMilliliters
    [Theory]
    [InlineData(1, 1000)]
    [InlineData(2, 2000)]
    [InlineData(0, 0)]
    public void LitersToMilliliters_VariousInputs_ReturnsExpectedMilliliters(int liters, int expected)
    {
        int result = RecipeHelpers.LitersToMilliliters(liters);
        Assert.Equal(expected, result);
    }

    // 3. CalculateMilkWeightGrams
    [Fact]
    public void CalculateMilkWeightGrams_GivenVolume_ReturnsWeight()
    {
        int volumeMl = 1000;

        double result = RecipeHelpers.CalculateMilkWeightGrams(volumeMl);

        Assert.Equal(1030.0, result);
    }

    // 4. IsValidBatchSize
    [Theory]
    [InlineData(100, true)]
    [InlineData(1, true)]
    [InlineData(0, false)]
    [InlineData(-50, false)]
    public void IsValidBatchSize_VariousInputs_ReturnsExpectedValidity(int totalMl, bool expected)
    {
        bool result = RecipeHelpers.IsValidBatchSize(totalMl);
        Assert.Equal(expected, result);
    }

    // 5. FormatTankLabel
    [Theory]
    [InlineData(1, "Chocolate", "Tank-1: Chocolate")]
    [InlineData(7, "Vanilla", "Tank-7: Vanilla")]
    public void FormatTankLabel_GivenIdAndContents_ReturnsFormattedString(int tankId, string contents, string expected)
    {
        string result = RecipeHelpers.FormatTankLabel(tankId, contents);
        Assert.Equal(expected, result);
    }

    // 6. CalculateRequiredBottles
    [Theory]
    [InlineData(250, 1)]   // exact fit
    [InlineData(251, 2)]   // rounds up
    [InlineData(500, 2)]
    [InlineData(0, 0)]
    public void CalculateRequiredBottles_VariousVolumes_ReturnsExpectedBottleCount(int totalVolumeMl, int expected)
    {
        int result = RecipeHelpers.CalculateRequiredBottles(totalVolumeMl);
        Assert.Equal(expected, result);
    }

    // 7. ApplyBulkDiscount
    [Theory]
    [InlineData(10.0, 10, 10.0)]      // below 50 -> no discount
    [InlineData(10.0, 50, 9.0)]       // >= 50 -> 10% off
    [InlineData(10.0, 100, 8.5)]      // >= 100 -> 15% off
    public void ApplyBulkDiscount_VariousBottleCounts_ReturnsExpectedPrice(decimal basePrice, int bottleCount, decimal expected)
    {
        decimal result = RecipeHelpers.ApplyBulkDiscount(basePrice, bottleCount);
        Assert.Equal(expected, result);
    }

    // 8. CalculateSugarGrams
    [Fact]
    public void CalculateSugarGrams_GivenVolume_ReturnsExpectedGrams()
    {
        int volumeMl = 240;

        double result = RecipeHelpers.CalculateSugarGrams(volumeMl);

        Assert.Equal(24.0, result);
    }

    // 9. NeedsMaintenance
    [Theory]
    [InlineData(0, false)]
    [InlineData(-100, false)]
    [InlineData(499, false)]
    [InlineData(500, true)]
    [InlineData(1000, true)]
    public void NeedsMaintenance_VariousBatchCounts_ReturnsExpectedResult(int totalBatchesRun, bool expected)
    {
        bool result = RecipeHelpers.NeedsMaintenance(totalBatchesRun);
        Assert.Equal(expected, result);
    }
}