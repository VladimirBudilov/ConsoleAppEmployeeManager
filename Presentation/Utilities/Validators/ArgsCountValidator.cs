using System;

namespace Presentation.Utilities.Validators;

public class ArgsCountValidator
{
    public bool Validate(string[] args, int expectedCount)
    {
        if (args.Length != expectedCount)
        {
            Console.WriteLine($"Expected {expectedCount} arguments, but got {args.Length}.");
            return false;
        }

        return true;
    }
}