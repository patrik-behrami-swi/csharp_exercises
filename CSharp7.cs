namespace CSharpFeaturesExercise;

public class CSharp7
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
        MathResult mathResult = Calculate(x, y, op);

        var result = mathResult.Result;
        var explanation = mathResult.Explanation;

        // assert
        result.Should().Be(expectedResult);
        explanation.Should().Be(expectedExplanation);
    }

    // HINT: Is it really needed to define separate class only to return the value from the function?
    private class MathResult {
        public int Result { get; set; }
        public string Explanation { get; set; }
    }

    private MathResult Calculate(int x, int y, MathOperation operation) {
        switch (operation){
            case MathOperation.ADDITION:
                return new MathResult { Result = x + y, Explanation = "Adding" };
            case MathOperation.SUBTRACTION:
                return new MathResult { Result = x - y, Explanation = "Subtracting" };
            case MathOperation.MULTIPLICATION:
                return new MathResult { Result = x * y, Explanation = "Multiplying" };
            case MathOperation.DIVISION:
                return new MathResult { Result = x / y, Explanation = "Dividing" };
            default:
                return new MathResult { Result = int.MinValue, Explanation = "Invalid operation"};
        }
    }

    public enum MathOperation {
        ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION
    }
    
}