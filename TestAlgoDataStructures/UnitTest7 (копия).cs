using AlgorithmsDataStructures2;

namespace SimpleGraphTests
{
    [TestClass]
    public class SimpleGraphTests
    {
        [TestMethod]
        public void VertexExistsNoConnections()
        {
            SimpleGraph graph = new SimpleGraph(5);

            graph.AddVertex(1);

            Assert.IsNotNull(graph.vertex[0]);
            for (int i = 0; i < graph.max_vertex; i++)
            {
                Assert.AreEqual(0, graph.m_adjacency[0, i]);
                Assert.AreEqual(0, graph.m_adjacency[i, 0]);
            }
        }

        [TestMethod]
        public void AddEdgeNoPreviousConnectionConnectionExists()
        {
            SimpleGraph graph = new SimpleGraph(5);
            graph.AddVertex(1);
            graph.AddVertex(2);

            graph.AddEdge(0, 1);

            Assert.IsTrue(graph.IsEdge(0, 1));
            Assert.IsTrue(graph.IsEdge(1, 0));
        }

        [TestMethod]
        public void RemoveEdgeConnectionExistedNoConnectionAfterRemoval()
        {
            SimpleGraph graph = new SimpleGraph(5);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddEdge(0, 1);

            graph.RemoveEdge(0, 1);

            Assert.IsFalse(graph.IsEdge(0, 1));
            Assert.IsFalse(graph.IsEdge(1, 0));
        }

        [TestMethod]
        public void RemoveVertexHadConnectionsNoConnectionsAfterRemoval()
        {
            SimpleGraph graph = new SimpleGraph(5);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);

            graph.RemoveVertex(0);

            Assert.IsNull(graph.vertex[0]);
            for (int i = 0; i < graph.max_vertex; i++)
            {
                Assert.AreEqual(0, graph.m_adjacency[0, i]);
                Assert.AreEqual(0, graph.m_adjacency[i, 0]);
            }
        }
    }
}
