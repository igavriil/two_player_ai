using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using TwoPlayerAi.Graphs;
using TwoPlayerAi.AdjacencyMatrices;
using Xunit;

namespace TwoPlayerAi.Tests.Graphs
{
    public class UndirectedDenseGraph
    {
        private readonly UndirectedDenseGraph<String> _graph;

        public UndirectedDenseGraph()
        {
            _graph = new UndirectedDenseGraph<string>();

            string[] vertices = new string[] { "a", "b", "c", "d", "e"};

            _graph.AddVertices(vertices);

            Assert.Equal(_graph.SetEdge("a", "c", 1), true);
            Assert.Equal(_graph.SetEdge("a", "b", 1), true);
            Assert.Equal(_graph.SetEdge("c", "d", 1), true);
            Assert.Equal(_graph.SetEdge("d", "e", 1), true);
            Assert.Equal(_graph.SetEdge("d", "a", 1), true);
            Assert.Equal(_graph.SetEdge("e", "c", 1), true);
        }

        [Fact]
        public void ShouldSetVertices()
        {
            List<String> vertices = _graph.Vertices.ToList();
            Assert.Equal(vertices.Count, _graph.VerticesCount);
            Assert.Equal(5, vertices.Count);

            Assert.Equal(vertices, new List<String>{ "a", "b", "c", "d", "e" } );
        }

        [Fact]
        public void ShouldReturnOutgoingEdgesOfVertex()
        {
            List<Edge<String>> edgesOfA = _graph.OutgoingEdges("a").Cast<Edge<String>>().ToList();
            List<Edge<String>> edgesOfB = _graph.OutgoingEdges("b").Cast<Edge<String>>().ToList();
            List<Edge<String>> edgesOfC = _graph.OutgoingEdges("c").Cast<Edge<String>>().ToList();
            List<Edge<String>> edgesOfD = _graph.OutgoingEdges("d").Cast<Edge<String>>().ToList();
            List<Edge<String>> edgesOfE = _graph.OutgoingEdges("e").Cast<Edge<String>>().ToList();

            Assert.Equal(edgesOfA, new List<Edge<String>>{
                new Edge<String>("a","b",1),
                new Edge<String>("a","c",1),
                new Edge<String>("a","d",1) } );
            Assert.Equal(edgesOfB, new List<Edge<String>>{
                new Edge<String>("b","a",1)} );
            Assert.Equal(edgesOfC, new List<Edge<String>>{
                new Edge<String>("c","a",1),
                new Edge<String>("c","d",1),
                new Edge<String>("c","e",1) } );
            Assert.Equal(edgesOfD, new List<Edge<String>>{
                new Edge<String>("d","a",1),
                new Edge<String>("d","c",1),
                new Edge<String>("d","e",1) } );
            Assert.Equal(edgesOfE, new List<Edge<String>>{
                new Edge<String>("e","c",1),
                new Edge<String>("e","d",1) } );
        }

        [Fact]
        public void ShouldReturnIncomingEdgesOfVertex()
        {
            List<Edge<String>> edgesOfA = _graph.IncomingEdges("a").Cast<Edge<String>>().ToList();
            List<Edge<String>> edgesOfB = _graph.IncomingEdges("b").Cast<Edge<String>>().ToList();
            List<Edge<String>> edgesOfC = _graph.IncomingEdges("c").Cast<Edge<String>>().ToList();
            List<Edge<String>> edgesOfD = _graph.IncomingEdges("d").Cast<Edge<String>>().ToList();
            List<Edge<String>> edgesOfE = _graph.IncomingEdges("e").Cast<Edge<String>>().ToList();

            Assert.Equal(edgesOfA, new List<Edge<String>>{
                new Edge<String>("b","a",1),
                new Edge<String>("c","a",1),
                new Edge<String>("d","a",1) } );
            Assert.Equal(edgesOfB, new List<Edge<String>>{
                new Edge<String>("a","b",1) } );
            Assert.Equal(edgesOfC, new List<Edge<String>>{
                new Edge<String>("a","c",1),
                new Edge<String>("d","c",1),
                new Edge<String>("e","c",1) } );
            Assert.Equal(edgesOfD, new List<Edge<String>>{
                new Edge<String>("a","d",1),
                new Edge<String>("c","d",1),
                new Edge<String>("e","d",1) } );
            Assert.Equal(edgesOfE, new List<Edge<String>>{
                new Edge<String>("c","e",1),
                new Edge<String>("d","e",1) } );
        }

        [Fact]
        public void ShouldReturnNeighboursOfVertex()
        {
            List<String> neighboursOfA = _graph.Neighbours("a").ToList();
            List<String> neighboursOfB = _graph.Neighbours("b").ToList();
            List<String> neighboursOfC = _graph.Neighbours("c").ToList();
            List<String> neighboursOfD = _graph.Neighbours("d").ToList();
            List<String> neighboursOfE = _graph.Neighbours("e").ToList();
            
            Assert.Equal(neighboursOfA, new List<String>{ "b", "c", "d" } );
            Assert.Equal(neighboursOfB, new List<String>{ "a" } );
            Assert.Equal(neighboursOfC, new List<String>{ "a", "d", "e" } );
            Assert.Equal(neighboursOfD, new List<String>{ "a", "c", "e" } );
            Assert.Equal(neighboursOfE, new List<String>{ "c", "d" } );
        }

        [Fact]
        public void ShouldReturnDegreeOfVertex()
        {
            Assert.Equal(_graph.Degree("a"), 3);
            Assert.Equal(_graph.Degree("b"), 1);
            Assert.Equal(_graph.Degree("c"), 3);
            Assert.Equal(_graph.Degree("d"), 3);
            Assert.Equal(_graph.Degree("e"), 2);
        }

        [Fact]
        public void ShouldSetEdges()
        {
            List<Edge<String>> edges = _graph.Edges.Cast<Edge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(12, edges.Count);

            Assert.Equal(edges, new List<Edge<String>>{
                new Edge<String>("a","b",1),
                new Edge<String>("a","c",1),
                new Edge<String>("a","d",1),
                new Edge<String>("b","a",1),
                new Edge<String>("c","a",1),
                new Edge<String>("c","d",1),
                new Edge<String>("c","e",1),
                new Edge<String>("d","a",1),
                new Edge<String>("d","c",1),
                new Edge<String>("d","e",1),
                new Edge<String>("e","c",1),
                new Edge<String>("e","d",1) } );
        }

        [Fact]
        public void ShouldReturnTrueIfVertexExists()
        {
            Assert.Equal(true, _graph.HasVertex("a"));
            Assert.Equal(true, _graph.HasVertex("b"));
            Assert.Equal(true, _graph.HasVertex("c"));
            Assert.Equal(true, _graph.HasVertex("d"));
            Assert.Equal(true, _graph.HasVertex("e"));
        }

        [Fact]
        public void ShouldReturnFalseIfVertexDoesNotExist()
        {
            Assert.Equal(false, _graph.HasVertex("f"));
        }

        [Fact]
        public void ShouldRemoveVertexAndEdgesWhenVertexExists()
        {
            Assert.Equal(true, _graph.RemoveVertex("a"));

            List<String> vertices = _graph.Vertices.ToList();
            Assert.Equal(vertices.Count, _graph.VerticesCount);
            Assert.Equal(4, vertices.Count);

            List<Edge<String>> edges = _graph.Edges.Cast<Edge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(6, edges.Count);

            Assert.Equal(vertices, new List<String>{ "b", "c", "d", "e" } );

            Assert.Equal(edges, new List<Edge<String>>{
                new Edge<String>("c","d",1),
                new Edge<String>("c","e",1),
                new Edge<String>("d","c",1),
                new Edge<String>("d","e",1),
                new Edge<String>("e","c",1),
                new Edge<String>("e","d",1) } );
        }

        [Fact]
        public void ShouldNotRemoveEdgesWhenVertexDoesNotExist()
        {
            IList<String> vertices = _graph.Vertices.ToList();
            Assert.Equal(vertices.Count, _graph.VerticesCount);
            Assert.Equal(5, vertices.Count);

            Assert.Equal(false, _graph.RemoveVertex("f"));
            IList<Edge<String>> edges = _graph.Edges.ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(12, edges.Count);
        }

        [Fact]
        public void ShouldAddVertexWhenVertexDoesNotExist()
        {
            Assert.Equal(true, _graph.AddVertex("f"));
            List<String> vertices = _graph.Vertices.ToList();
            Assert.Equal(vertices.Count, _graph.VerticesCount);
            Assert.Equal(6, vertices.Count);

            Assert.Equal(vertices, new List<String>{ "a", "b", "c", "d", "e", "f" } );
        }

        [Fact]
        public void ShouldNotAddVertexWhenVertexExists()
        {
            Assert.Equal(false, _graph.AddVertex("b"));
            List<String> vertices = _graph.Vertices.ToList();
            Assert.Equal(vertices.Count, _graph.VerticesCount);
            Assert.Equal(5, vertices.Count);

            Assert.Equal(vertices, new List<String>{ "a", "b", "c", "d", "e"} );
        }

        [Fact]
        public void ShouldSetEdgeWhenEdgeDoesNotExist()
        {
            Assert.Equal(true, _graph.SetEdge("b", "c", 1));
            List<Edge<String>> edges = _graph.Edges.Cast<Edge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(14, edges.Count);

            Assert.Equal(edges, new List<Edge<String>>{
                new Edge<String>("a","b",1),
                new Edge<String>("a","c",1),
                new Edge<String>("a","d",1),
                new Edge<String>("b","a",1),
                new Edge<String>("b","c",1),
                new Edge<String>("c","a",1),
                new Edge<String>("c","b",1),
                new Edge<String>("c","d",1),
                new Edge<String>("c","e",1),
                new Edge<String>("d","a",1),
                new Edge<String>("d","c",1),
                new Edge<String>("d","e",1),
                new Edge<String>("e","c",1),
                new Edge<String>("e","d",1) } );
        }

        [Fact]
        public void ShouldNotSetEdgeWhenEdgeExists()
        {
            Assert.Equal(false, _graph.SetEdge("a", "b", 1));
            List<Edge<String>> edges = _graph.Edges.Cast<Edge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(12, edges.Count);
        }
        
        [Fact]
        public void ShouldNotSetEdgeWhenVertexDoesNotExist()
        {
            Assert.Equal(false, _graph.SetEdge("a", "f", 1));
            List<Edge<String>> edges = _graph.Edges.Cast<Edge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(12, edges.Count);
        }
    }
}