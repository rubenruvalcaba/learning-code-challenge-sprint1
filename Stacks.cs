using System.Collections.Generic;

public class Stacks
{
    public static string StackReversingStringExcercise(string input)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in input)
            stack.Push(c);

        return string.Join("", stack.ToArray());
    }

    #region  Balanced
    private const string openingChars = "({[<";
    private const string closingChars = ")}]>";

    public static bool IsStringBalanced(string expression)
    {

        Stack<char> openedGroups = new Stack<char>();

        foreach (char c in expression)
        {
            if (openingChars.IndexOf(c) > -1)
                openedGroups.Push(c);

            if (closingChars.Contains(c))
            {
                if (openedGroups.Count == 0)
                    return false;

                var lastOpeningChar = openedGroups.Pop();
                var indexLastOpeningChar = openingChars.IndexOf(lastOpeningChar);
                var expectedClosingChar = closingChars[indexLastOpeningChar];
                if (c != expectedClosingChar)
                    return false;
            }

        }
        return (openedGroups.Count == 0);
    }

    #endregion

}