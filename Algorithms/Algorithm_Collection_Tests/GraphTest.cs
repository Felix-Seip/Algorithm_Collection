using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithm_Collection.Graph;

namespace Algorithm_Collection_Tests
{
	[TestClass]
	public class GraphTest
	{
		public List<Graph> _Graphs;

		private const string cPathToTestData = @"TestData";
		[ClassInitialize]
		public void Init()
		{
			_Graphs = new List<Graph>();
			_Graphs.Add(new Graph(cPathToTestData + "CityMap.graph"));
			_Graphs.Add(new Graph(cPathToTestData + "Klausur.graph"));
		}

		[TestMethod]
		public void DijkstraTest()
		{
			Route actual;

			foreach(Graph g in _Graphs)
			{
				actual = Algorithm_Collection.GraphAlgorithm.Dijkstra.FindShortestPath(g);
			}


		}
	}
}
