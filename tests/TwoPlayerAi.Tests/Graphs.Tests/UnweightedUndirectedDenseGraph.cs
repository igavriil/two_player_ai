using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using TwoPlayerAi.Graphs;
using Xunit;

namespace TwoPlayerAi.Tests.Graphs
{
    public class UnweightedUndirectedDenseGraph
    {
        private readonly UnweightedUndirectedDenseGraph<String> _graph;

        public UnweightedUndirectedDenseGraph()
        {
            _graph = new UnweightedUndirectedDenseGraph<string>(10);

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
                new UnweightedEdge<String>("a","c"),
                new UnweightedEdge<String>("a","d") } );
            Assert.Equal(edgesOfB, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("b","a")} );
            Assert.Equal(edgesOfC, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("c","a"),
                new UnweightedEdge<String>("c","d"),
                new UnweightedEdge<String>("c","e") } );
            Assert.Equal(edgesOfD, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("d","a"),
                new UnweightedEdge<String>("d","c"),
                new UnweightedEdge<String>("d","e") } );
            Assert.Equal(edgesOfE, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("e","c"),
                new UnweightedEdge<String>("e","d") } );
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
                new UnweightedEdge<String>("b","a"),
                new UnweightedEdge<String>("c","a"),
                new UnweightedEdge<String>("d","a") } );
             Assert.Equal(edgesOfB, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","b") } );
            Assert.Equal(edgesOfC, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","c"),
                new UnweightedEdge<String>("d","c"),
                new UnweightedEdge<String>("e","c") } );
            Assert.Equal(edgesOfD, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","d"),
                new UnweightedEdge<String>("c","d"),
                new UnweightedEdge<String>("e","d") } );
            Assert.Equal(edgesOfE, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("c","e"),
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
            List<UnweightedEdge<String>> edges = _graph.Edges.Cast<UnweightedEdge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(12, edges.Count);

            Assert.Equal(edges, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","b"),
                new UnweightedEdge<String>("a","c"),
                new UnweightedEdge<String>("a","d"),
                new UnweightedEdge<String>("b","a"),
                new UnweightedEdge<String>("c","a"),
                new UnweightedEdge<String>("c","d"),
                new UnweightedEdge<String>("c","e"),
                new UnweightedEdge<String>("d","a"),
                new UnweightedEdge<String>("d","c"),
                new UnweightedEdge<String>("d","e"),
                new UnweightedEdge<String>("e","c"),
                new UnweightedEdge<String>("e","d") } );
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
            Assert.Equal(6, edges.Count);

            Assert.Equal(vertices, new List<String>{ "b", "c", "d", "e" } );

            Assert.Equal(edges, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("c","d"),
                new UnweightedEdge<String>("c","e"),
                new UnweightedEdge<String>("d","c"),
                new UnweightedEdge<String>("d","e"),
                new UnweightedEdge<String>("e","c"),
                new UnweightedEdge<String>("e","d") } );
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
        public void ShouldAddEdgeWhenEdgeDoesNotExist()
        {
            Assert.Equal(true, _graph.AddEdge("b", "c"));
            List<UnweightedEdge<String>> edges = _graph.Edges.Cast<UnweightedEdge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(14, edges.Count);

            Assert.Equal(edges, new List<UnweightedEdge<String>>{
                new UnweightedEdge<String>("a","b"),
                new UnweightedEdge<String>("a","c"),
                new UnweightedEdge<String>("a","d"),
                new UnweightedEdge<String>("b","a"),
                new UnweightedEdge<String>("b","c"),
                new UnweightedEdge<String>("c","a"),
                new UnweightedEdge<String>("c","b"),
                new UnweightedEdge<String>("c","d"),
                new UnweightedEdge<String>("c","e"),
                new UnweightedEdge<String>("d","a"),
                new UnweightedEdge<String>("d","c"),
                new UnweightedEdge<String>("d","e"),
                new UnweightedEdge<String>("e","c"),
                new UnweightedEdge<String>("e","d") } );
        }

        [Fact]
        public void ShouldNotAddEdgeWhenEdgeExists()
        {
            Assert.Equal(false, _graph.AddEdge("a", "b"));
            List<UnweightedEdge<String>> edges = _graph.Edges.Cast<UnweightedEdge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(12, edges.Count);
        }

        public void ShouldNotAddEdgeWhenVertexDoesNotExist()
        {
            Assert.Equal(false, _graph.AddEdge("a", "f"));
            List<UnweightedEdge<String>> edges = _graph.Edges.Cast<UnweightedEdge<String>>().ToList();
            Assert.Equal(edges.Count, _graph.EdgesCount);
            Assert.Equal(6, edges.Count);
        }
    }
}