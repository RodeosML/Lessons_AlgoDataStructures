using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;

namespace Tests
{
    [TestClass]
    public class aBSTTests
    {
        [TestMethod]
        public void TestAddKey()
        {
            aBST tree = new aBST(3); // глубина 3 должна создать дерево с 15 элементами
            int key = 5;

            int index = tree.AddKey(key);

            Assert.AreEqual(-1, index); // индекс корня должен быть 0
        }

        [TestMethod]
        public void TestFindKeyIndex()
        {
            aBST tree = new aBST(3);
            int key = 5;
            tree.AddKey(10);
            tree.AddKey(3);
            tree.AddKey(7);
            tree.AddKey(15);

            int? index = tree.FindKeyIndex(key);

            Assert.IsNull(index);
        }
    }
}
