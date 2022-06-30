using NUnit.Framework;

namespace NBack.Tests
{
    public sealed class ValueTupleTests
    {
        [Test]
        public void NoArity()
        {
            System.ValueTuple tuple = System.ValueTuple.Create(), tuple2 = new();

            Assert.AreEqual(tuple2, tuple);
            Assert.AreEqual(tuple.CompareTo(tuple2), 0);
            Assert.AreEqual(tuple.GetHashCode(), 0);
            Assert.Throws<ArgumentException>(() => ((IComparable)tuple2).CompareTo('a'));
            Assert.AreEqual(((IComparable)tuple2).CompareTo(null), 1);
            Assert.AreEqual(tuple2.ToString(), "()");
        }

		[Test]
        public void OneArity()
		{
            ValueTuple<int> tuple = System.ValueTuple.Create(6), tuple2 = new(42);

            Assert.AreNotEqual(tuple2, tuple);
            Assert.Less(tuple, tuple2);
            Assert.Greater(tuple2, tuple);
            Assert.AreEqual(tuple2.GetHashCode(), 42.GetHashCode());
            Assert.Throws<ArgumentException>(() => ((IComparable)tuple).CompareTo('a'));
            Assert.AreEqual(((IComparable)tuple2).CompareTo(null), 1);
            Assert.AreEqual(tuple2.ToString(), "(42)");
        }
    }
}
