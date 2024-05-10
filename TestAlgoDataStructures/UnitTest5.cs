using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures4;

namespace Tests
{
    [TestClass]
    public class BalancedBSTTests
    {
        [TestMethod]
        public void GenerateBBSTArrayReturnsBSTArray()
        {
            int[] unsortedArray = { 5, 3, 6, 1, 4, 7, 2 };
            int[] expectedResult = { 4, 2, 6, 1, 3, 5, 7 };

            int[] result = BalancedBST.GenerateBBSTArray(unsortedArray);

            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}