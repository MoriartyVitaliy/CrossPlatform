using Lab3.Library;

namespace Lab3.Tests
{
    public class ListComparerTests
    {
        [Fact]
        public void Equals_ShouldReturnTrueForEqualLists()
        {
            // Arrange
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 1, 2, 3 };
            var comparer = new ListComparer();

            // Act
            bool areEqual = comparer.Equals(list1, list2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Equals_ShouldReturnFalseForDifferentLists()
        {
            // Arrange
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 3, 2, 1 };
            var comparer = new ListComparer();

            // Act
            bool areEqual = comparer.Equals(list1, list2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void GetHashCode_ShouldReturnSameHashCodeForEqualLists()
        {
            // Arrange
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 1, 2, 3 };
            var comparer = new ListComparer();

            // Act
            int hash1 = comparer.GetHashCode(list1);
            int hash2 = comparer.GetHashCode(list2);

            // Assert
            Assert.Equal(hash1, hash2);
        }
    }
}