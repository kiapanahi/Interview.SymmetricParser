namespace Parser;

public class Vocabulary : Dictionary<char, char>
{
    public static Vocabulary SimpleVocabulary { get; }
    static Vocabulary()
    {
        SimpleVocabulary = new(new[] {
            new KeyValuePair<char, char>('(', ')'),
            new KeyValuePair<char, char>('{', '}'),
            new KeyValuePair<char, char>('[', ']'),
            new KeyValuePair<char, char>('<', '>'),
        });
    }

    public Vocabulary(IEnumerable<KeyValuePair<char, char>> input) : base(input)
    {

    }

    public bool AreDuals(char left, char right)
    {
        bool tryGetResult = TryGetValue(left, out char counterPart);
        if (tryGetResult is false)
        {
            return false;
        }

        return counterPart == right;
    }

}
