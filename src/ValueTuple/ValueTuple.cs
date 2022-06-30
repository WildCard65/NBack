using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

/// <summary>
/// The ValueTuple types (from arity 0 to 8) comprise the runtime implementation that underlies tuples in C# and struct tuples in F#.
/// Aside from created via language syntax, they are most easily created via the ValueTuple.Create factory methods.
/// The System.ValueTuple types differ from the System.Tuple types in that:<br />
/// - they are structs rather than classes,<br />
/// - they are mutable rather than readonly, and<br />
/// - their members (such as Item1, Item2, etc) are fields rather than properties.
/// </summary>
[Serializable]
public struct ValueTuple : IEquatable<ValueTuple>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<ValueTuple>, IValueTupleInternal, ITuple
{
    /// <summary>Returns a value that indicates whether the current <see cref="ValueTuple" /> instance is equal to a specified object.</summary>
    /// <param name="obj">The object to compare with this instance.</param>
    /// <returns><see langword="true"/> if <paramref name="obj"/> is a <see cref="ValueTuple" />.</returns>
    public override bool Equals(object? obj) => obj is ValueTuple;

    /// <summary>Returns a value indicating whether this instance is equal to a specified value.</summary>
    /// <param name="other">An instance to compare to this instance.</param>
    /// <returns>true if <paramref name="other" /> has the same value as this instance; otherwise, false.</returns>
    public bool Equals(ValueTuple other) => true;

    bool IStructuralEquatable.Equals(object? other, IEqualityComparer comparer) => other is ValueTuple;

    int IComparable.CompareTo(object? obj) => obj switch
    {
        null => 1,
        ValueTuple => 0,
        _ => throw NBack.ValueTuple.ThrowHelpers.ValueTuple_ArgumentException(this)
    };

    /// <summary>Compares this instance to a specified instance and returns an indication of their relative values.</summary>
    /// <param name="other">An instance to compare.</param>
    /// <returns>
    /// A signed number indicating the relative values of this instance and <paramref name="other" />.
    /// Returns less than zero if this instance is less than <paramref name="other" />, zero if this
    /// instance is equal to <paramref name="other" />, and greater than zero if this instance is greater
    /// than <paramref name="other" />.
    /// </returns>
    public int CompareTo(ValueTuple other) => 0;

    int IStructuralComparable.CompareTo(object? obj, IComparer comparer) => obj switch
    {
        null => 1,
        ValueTuple => 0,
        _ => throw NBack.ValueTuple.ThrowHelpers.ValueTuple_ArgumentException(this)
    };

    /// <summary>Returns the hash code for this instance.</summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode() => 0;

    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => 0;

    int IValueTupleInternal.GetHashCode(IEqualityComparer comparer) => 0;

    /// <summary>Returns a string that represents the value of this <see cref="ValueTuple" /> instance.</summary>
    /// <returns>The string representation of this <see cref="ValueTuple" /> instance.</returns>
    /// <remarks>The string returned by this method takes the form <c>()</c>.</remarks>
    public override string ToString() => "()";

    string IValueTupleInternal.ToStringEnd() => ")";

    /// <summary>The number of positions in this data structure.</summary>
    int ITuple.Length => 0;

    /// <summary>Get the element at position <param name="index" />.</summary>
    object? ITuple.this[int index] => throw new IndexOutOfRangeException();

    /// <summary>Creates a new struct 0-tuple.</summary>
    /// <returns>A 0-tuple.</returns>
    public static ValueTuple Create() => default;
}
