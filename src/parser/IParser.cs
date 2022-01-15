namespace Parser;

public interface IParser
{
    bool IsValid(string input, Vocabulary vocabulary);
    bool IsValid(string input);
}
