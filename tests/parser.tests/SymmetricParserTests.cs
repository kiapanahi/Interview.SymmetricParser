using Xunit;

namespace Parser.Tests;

public class SymmetricParserTests
{
    [Theory]
    [InlineData("", true)]
    [InlineData(" ", false)]
    [InlineData("[]", true)]
    [InlineData("<>", true)]
    [InlineData("{}", true)]
    [InlineData("()", true)]
    [InlineData("([])", true)]
    [InlineData("[()]", true)]
    [InlineData("<", false)]
    [InlineData("[", false)]
    [InlineData("{", false)]
    [InlineData("(", false)]
    [InlineData(">", false)]
    [InlineData("]", false)]
    [InlineData("}", false)]
    [InlineData(")", false)]
    [InlineData("[(]", false)]
    [InlineData("[](", false)]
    [InlineData("[ab]", false)]
    [InlineData("{{{{{{{{{{}}}}}}}}}}", true)]
    [InlineData("{{{{{{{{{{]]]]]]]]]]", false)]
    [InlineData("({})<{()}>[]", true)]
    [InlineData("({})<{<(>)}>[]", false)]
    [InlineData("({})<{(<>)}>[]", true)]
    [InlineData("{{({})<{(<>)}>[]}}", true)]
    public void ValidatesInputes(string input, bool expectedResult)
    {
        IParser parser = new SymmetricParser();
        Assert.Equal(expectedResult, parser.IsValid(input));
    }
}