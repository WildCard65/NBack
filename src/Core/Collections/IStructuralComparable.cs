namespace System.Collections;

/// <summary>Supports the structural comparison of collection objects.</summary>
public interface IStructuralComparable
{
    /// <summary>Determines whether the current collection object precedes, occurs in the same position as, or follows another object in the sort order.</summary>
    /// <param name="other">The object to compare with the current instance.</param>
    /// <param name="comparer">An object that compares members of the current collection object with the corresponding members of <paramref name="other" />.</param>
    /// <returns>
    ///     A signed integer that indicates the relationship of the current collection object to other in the sort order:<br />
    ///     - If less than 0, the current instance precedes <paramref name="other" />.<br />
    ///     - If 0, the current instance and <paramref name="other" /> are equal.<br />
    ///     - If greater than 0, the current instance follows <paramref name="other" />.
    /// </returns>
    int CompareTo(object? other, IComparer comparer);
}
