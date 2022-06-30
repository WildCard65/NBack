namespace NBack.ValueTuple;

internal static class ThrowHelpers
{
    public static ArgumentException ValueTuple_ArgumentException(object obj) => new($"Argument must be of type {obj.GetType()}.");
}
