using AlgorithmsDataStructures6;

namespace BalancedBSTTests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void TestMakeHeap()
        {
            Heap heap = new Heap();
            int[] array = { 12, 8, 5, 4, 19, 15, 21 };
            heap.MakeHeap(array, 2);

            int[] comparedArray = { 21, 12, 19, 4, 8, 5, 15 };
            CollectionAssert.AreEqual(comparedArray, heap.HeapArray); ;
        }

        [TestMethod]
        public void TestAddAndGetMax()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 5, 3, 8, 2, 7 }, 3);

            heap.Add(10);
            Assert.AreEqual(10, heap.GetMax());

            heap.Add(1);
            Assert.AreEqual(8, heap.GetMax());
        }

        [TestMethod]
        public void TestAddWhenHeapFull()
        {
            Heap heap = new Heap();
            int[] array = { 12, 8, 5, 4, 19, 15, 21 };
            heap.MakeHeap(array, 2);

            Assert.IsFalse(heap.Add(9));
        }

        [TestMethod]
        public void TestGetMaxWhenEmpty()
        {
            Heap heap = new Heap();

            Assert.AreEqual(-1, heap.GetMax());
        }
    }
}
