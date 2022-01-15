namespace Parser;

public sealed class SymmetricParser : IParser
{
    public bool IsValid(string input, Vocabulary vocabulary)
    {
        Stack<char> stack = new();

        foreach (char character in input)
        {
            if (stack.TryPeek(out char tots) && vocabulary.AreDuals(tots, character))
            {
                stack.Pop();
            }
            else
            {
                stack.Push(character);
            }
        }

        return stack.Count == 0;
    }

    public bool IsValid(string input)
    {
        return IsValid(input, Vocabulary.SimpleVocabulary);
    }
}
