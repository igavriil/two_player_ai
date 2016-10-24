using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using TwoPlayerAi.Framework.Graphs;
using Xunit;

namespace TwoPlayerAi.UnitTests.Framework.Graphs
{
    public class UndirectedUnweightedDenseGraph
    {
        private readonly UnweightedDenseGraph<String> _graph;

        public UndirectedUnweightedDenseGraph()
        {
           _graph = new UnweightedDenseGraph<string>(10, directed: false);

            string[] vertices = new string[] { "a", "b", "c", "d", "e"};

            _graph.AddVertices(vertices);

            Assert.Equal(_graph.AddEdge("a", "c"), true);
            Assert.Equal(_graph.AddEdge("a", "b"), true);
            Assert.Equal(_graph.AddEdge("c", "d"), true);
            Assert.Equal(_graph.AddEdge("d", "e"), true);
            Assert.Equal(_graph.AddEdge("d", "a"), true);
            Assert.Equal(_graph.AddEdge("e", "c"), true);
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
            List<UnweightedEdge<String>> edgesOfA = _graph.OutgoingEdges("a").Cast<UnweightedEdge<String>>().ToList();
            List<UnweightedEdge<String>> edgesOfB = _graph.OutgoingEdges("b").Cast<UnweightedEdge<String>>().ToList();
            List<UnweightedEdge<String>> edgesOfC = _graph.OutgoingEdges("c").Cast<UnweightedEdge<String>>().ToList();
            List<UnweightedEdge<String>> edgesOfD = _graph.OutgoingEdges("d").Cast<UnweightedEdge<String>>().ToList();
            List<UnweightedEdge<String>> edgesOfE = _graph.OutgoingEdges("e").Cast<UnweightedEdge<String>>().ToList();

            Assert.Equal(edgesOfA, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","b"),
                new UnweightedEdge<String>("a","c") } );
            Assert.Equal(edgesOfB, new List<UnweightedEdge<String>>{} );
            Assert.Equal(edgesOfC, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("c","d") } );
            Assert.Equal(edgesOfD, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("d","a"),
                new UnweightedEdge<String>("d","e") } );
            Assert.Equal(edgesOfE, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("e","c") } );
        }

        [Fact]
        public void ShouldReturnIncomingEdgesOfVertex()
        {
            List<UnweightedEdge<String>> edgesOfA = _graph.IncomingEdges("a").Cast<UnweightedEdge<String>>().ToList();
            List<UnweightedEdge<String>> edgesOfB = _graph.IncomingEdges("b").Cast<UnweightedEdge<String>>().ToList();
            List<UnweightedEdge<String>> edgesOfC = _graph.IncomingEdges("c").Cast<UnweightedEdge<String>>().ToList();
            List<UnweightedEdge<String>> edgesOfD = _graph.IncomingEdges("d").Cast<UnweightedEdge<String>>().ToList();
            List<UnweightedEdge<String>> edgesOfE = _graph.IncomingEdges("e").Cast<UnweightedEdge<String>>().ToList();

            Assert.Equal(edgesOfA, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("d","a") } );
             Assert.Equal(edgesOfB, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","b") } );
            Assert.Equal(edgesOfC, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","c"),
                new UnweightedEdge<String>("e","c") } );
            Assert.Equal(edgesOfD, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("c","d") } );
            Assert.Equal(edgesOfE, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("d","e") } );
        }

        [Fact]
        public void ShouldReturnNeighboursOfVertex()
        {
            List<String> neighboursOfA = _graph.Neighbours("a").ToList();
            List<String> neighboursOfB = _graph.Neighbours("b").ToList();
            List<String> neighboursOfC = _graph.Neighbours("c").ToList();
            List<String> neighboursOfD = _graph.Neighbours("d").ToList();
            List<String> neighboursOfE = _graph.Neighbours("e").ToList();
            
            Assert.Equal(neighboursOfA, new List<String>{ "b", "c" } );
            Assert.Equal(neighboursOfB, new List<String>{ } );
            Assert.Equal(neighboursOfC, new List<String>{ "d" } );
            Assert.Equal(neighboursOfD, new List<String>{ "a", "e" } );
            Assert.Equal(neighboursOfE, new List<String>{ "c" } );
        }

        [Fact]
        public void ShouldReturnDegreeOfVertex()
        {
            Assert.Equal(_graph.Degree("a"), 2);
            Assert.Equal(_graph.Degree("b"), 0);
            Assert.Equal(_graph.Degree("c"), 1);
            Assert.Equal(_graph.Degree("d"), 2);
            Assert.Equal(_graph.Degree("e"), 1);
        }

        [Fact]
        public void ShouldSetEdges()
        {
            List<UnweightedEdge<String>> edges = _graph.Edges.Cast<UnweightedEdge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(6, edges.Count);

            Assert.Equal(edges, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","b"),
                new UnweightedEdge<String>("a","c"),
                new UnweightedEdge<String>("c","d"),
                new UnweightedEdge<String>("d","a"),
                new UnweightedEdge<String>("d","e"),
                new UnweightedEdge<String>("e","c") } );
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

            List<UnweightedEdge<String>> edges = _graph.Edges.Cast<UnweightedEdge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(3, edges.Count);

            Assert.Equal(vertices, new List<String>{ "b", "c", "d", "e" } );

            Assert.Equal(edges, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("c","d"),
                new UnweightedEdge<String>("d","e"),
                new UnweightedEdge<String>("e","c") } );
        }

        [Fact]
        public void ShouldNotRemoveEdgesWhenVertexDoesNotExist()
        {
            IList<String> vertices = _graph.Vertices.ToList();
            Assert.Equal(vertices.Count, _graph.VerticesCount);
            Assert.Equal(5, vertices.Count);

            Assert.Equal(false, _graph.RemoveVertex("f"));
            IList<IEdge<String>> edges = _graph.Edges.ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(6, edges.Count);
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
        public void ShouldAddEdgeWhenEdgeDoesNotExist()
        {
            Assert.Equal(true, _graph.AddEdge("b", "c"));
            List<UnweightedEdge<String>> edges = _graph.Edges.Cast<UnweightedEdge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(7, edges.Count);

            Assert.Equal(edges, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","b"),
                new UnweightedEdge<String>("a","c"),
                new UnweightedEdge<String>("b","c"),
                new UnweightedEdge<String>("c","d"),
                new UnweightedEdge<String>("d","a"),
                new UnweightedEdge<String>("d","e"),
                new UnweightedEdge<String>("e","c") } );
        }

        [Fact]
        public void ShouldNotAddEdgeWhenEdgeExists()
        {
            Assert.Equal(false, _graph.AddEdge("a", "b"));
            List<UnweightedEdge<String>> edges = _graph.Edges.Cast<UnweightedEdge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(6, edges.Count);

            Assert.Equal(edges, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","b"),
                new UnweightedEdge<String>("a","c"),
                new UnweightedEdge<String>("c","d"),
                new UnweightedEdge<String>("d","a"),
                new UnweightedEdge<String>("d","e"),
                new UnweightedEdge<String>("e","c") } );
        }

        public void ShouldNotAddEdgeWhenVertexDoesNotExist()
        {
            Assert.Equal(false, _graph.AddEdge("a", "f"));
            List<UnweightedEdge<String>> edges = _graph.Edges.Cast<UnweightedEdge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(6, edges.Count);

            Assert.Equal(edges, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","b"),
                new UnweightedEdge<String>("a","c"),
                new UnweightedEdge<String>("c","d"),
                new UnweightedEdge<String>("d","a"),
                new UnweightedEdge<String>("d","e"),
                new UnweightedEdge<String>("e","c") } );
        }
    }
}