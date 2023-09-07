namespace CSharpFeaturesExercise;

public class CSharp8
{
    [Theory]
    [InlineData(1, 2, MathOperation.ADDITION, 3, "Adding")]
    [InlineData(2, 5, MathOperation.SUBTRACTION, -3, "Subtracting")]
    [InlineData(4, 4, MathOperation.MULTIPLICATION, 16, "Multiplying")]
    [InlineData(4, 2, MathOperation.DIVISION, 2, "Dividing")]
    public void Calculate_ReturnCorrectResult(int x, int y, MathOperation op, int expectedResult, string expectedExplanation)
    {
        // arrange - empty

        // act
        var mathResult = Calculate(x, y, op);

        var result = mathResult.Result;
        var explanation = mathResult.Explanation;

        // assert
        result.Should().Be(expectedResult);
        explanation.Should().Be(expectedExplanation);
    }


    // HINT: This calculate function is a little bloated and could be more concise 
    private (int Result, string Explanation) Calculate(int x, int y, MathOperation operation) {
        switch (operation){
            case MathOperation.ADDITION:
                return (x + y, "Adding");
            case MathOperation.SUBTRACTION:
                return (x - y, "Subtracting");
            case MathOperation.MULTIPLICATION:
                return (x * y, "Multiplying");
            case MathOperation.DIVISION:
                return (x / y, "Dividing");
            default:
                return (int.MinValue, "Invalid operation");
        }
    }

    public enum MathOperation {
        ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION
    }
}