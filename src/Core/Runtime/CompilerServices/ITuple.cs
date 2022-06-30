namespace System.Runtime.CompilerServices;

/// <summary>This interface is required for types that want to be indexed into by dynamic patterns.</summary>
public interface ITuple
{
    /// <summary>The number of positions in this data structure.</summary>
    int Length { get; }

    /// <summary>Gets the element at position <paramref name="index" />.</summary>
    /// <param name="index">The zero-based index in this data structure.</param>
    object? this[int index] { get; }
}
