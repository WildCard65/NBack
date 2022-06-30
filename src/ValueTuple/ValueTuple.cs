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
#if !NET20 && !NET35
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
#endif
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

	/// <summary>Creates a new struct 1-tuple, or singleton.</summary>
	/// <typeparam name="T1">The type of the first component of the tuple.</typeparam>
	/// <param name="item1">The value of the first component of the tuple.</param>
	/// <returns>A 1-tuple (singleton) whose value is (item1).</returns>
	public static ValueTuple<T1> Create<T1>(T1 item1) => new(item1);
}

/// <summary>Represents a 1-tuple, or singleton, as a value type.</summary>
/// <typeparam name="T1">The type of the tuple's only component.</typeparam>
[Serializable]
#if !NET20 && !NET35
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
#endif
public struct ValueTuple<T1> : IEquatable<ValueTuple<T1>>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<ValueTuple<T1>>, IValueTupleInternal, ITuple
{
	/// <summary>The current <see cref="ValueTuple{T1}" /> instance's first component.</summary>
	public T1 Item1;

	/// <summary>Initializes a new instance of the <see cref="ValueTuple{T1}"/> value type.</summary>
	/// <param name="item1">The value of the tuple's first component.</param>
	public ValueTuple(T1 item1) => Item1 = item1;

	/// <summary>Returns a value that indicates whether the current <see cref="ValueTuple{T1}" /> instance is equal to a specified object.</summary>
	/// <param name="obj">The object to compare with this instance.</param>
	/// <returns><see langword="true" /> if the current instance is equal to the specified object; otherwise, <see langword="false" />.</returns>
	/// <remarks>
	/// The <paramref name="obj" /> parameter is considered to be equal to the current instance under the following conditions:
	/// <list type="bullet">
	///     <item><description>It is a <see cref="ValueTuple{T1}" /> value type.</description></item>
	///     <item><description>Its components are of the same types as those of the current instance.</description></item>
	///     <item><description>Its components are equal to those of the current instance. Equality is determined by the default object equality comparer for each component.</description></item>
	/// </list>
	/// </remarks>
	public override bool Equals(object? obj) => obj is ValueTuple<T1> tuple && Equals(tuple);

	/// <summary>Returns a value that indicates whether the current <see cref="ValueTuple{T1}" /> instance is equal to a specified <see cref="ValueTuple{T1}" />.</summary>
	/// <param name="other">The tuple to compare with this instance.</param>
	/// <returns><see langword="true" /> if the current instance is equal to the specified tuple; otherwise, <see langword="false" />.</returns>
	/// <remarks>
	/// The <paramref name="other" /> parameter is considered to be equal to the current instance if each of its field
	/// is equal to that of the current instance, using the default comparer for that field's type.
	/// </remarks>
	public bool Equals(ValueTuple<T1> other) => EqualityComparer<T1>.Default.Equals(Item1, other.Item1);

	bool IStructuralEquatable.Equals(object? other, IEqualityComparer comparer) => other is ValueTuple<T1> tuple && comparer.Equals(Item1, tuple.Item1);

	int IComparable.CompareTo(object? obj) => obj switch
	{
		null => 1,
		ValueTuple<T1> tuple => Comparer<T1>.Default.Compare(Item1, tuple.Item1),
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
	public int CompareTo(ValueTuple<T1> other) => Comparer<T1>.Default.Compare(Item1, other.Item1);

	int IStructuralComparable.CompareTo(object? obj, IComparer comparer) => obj switch
	{
		null => 1,
		ValueTuple<T1> tuple => comparer.Compare(Item1, tuple.Item1),
		_ => throw NBack.ValueTuple.ThrowHelpers.ValueTuple_ArgumentException(this)
	};

	/// <summary>Returns the hash code for the current <see cref="ValueTuple{T1}" /> instance.</summary>
	/// <returns>A 32-bit signed integer hash code.</returns>
	public override int GetHashCode() => Item1?.GetHashCode() ?? 0;

	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => comparer.GetHashCode(Item1!);

	int IValueTupleInternal.GetHashCode(IEqualityComparer comparer) => comparer.GetHashCode(Item1!);

	/// <summary>Returns a string that represents the value of this <see cref="ValueTuple{T1}" /> instance.</summary>
	/// <returns>The string representation of this <see cref="ValueTuple{T1}" /> instance.</returns>
	/// <remarks>
	/// The string returned by this method takes the form <c>(Item1)</c>,
	/// where <c>Item1</c> represents the value of <see cref="Item1" />. If the field is <see langword="null" />,
	/// it is represented as <see cref="string.Empty" />.
	/// </remarks>
	public override string ToString() => $"({Item1?.ToString()})";

	string IValueTupleInternal.ToStringEnd() => $"{Item1?.ToString()})";

	/// <summary>The number of positions in this data structure.</summary>
	int ITuple.Length => 1;

	/// <summary>Get the element at position <param name="index" />.</summary>
	object? ITuple.this[int index] => index is 0 ? Item1 : throw new IndexOutOfRangeException();
}
