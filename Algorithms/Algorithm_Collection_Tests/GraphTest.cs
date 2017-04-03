using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithm_Collection.Graph;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Algorithm_Collection_Tests
{
	[TestClass]
	public class GraphTest
	{

		public struct TestData
		{
			public string Filename;
			public Graph Graph;
			public Node Start;
			public Node End;
			public string Hash;

			public TestData(string file)
			{
				Filename = file;
				Graph = ImportGraphFromFile(Filename);
				Start = Graph.FindNodeByName("START");
				End = Graph.FindNodeByName("END");
				Hash = GetHashForFile(file);
			}
		}

		public static List<TestData> TestDatas;

		private static readonly string PathToProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
		private const string cPathToTestData = @"TestData";

		[ClassInitialize]
		public static void Init(TestContext tc)
		{
			TestDatas = new List<TestData>();

			TestDatas.Add(new TestData(GetPathToTestFile("Klausur.graph")));
			TestDatas.Add(new TestData(GetPathToTestFile("CityMap.graph")));
		}

		[ClassCleanup]
		public static void Clean()
		{
			string path = GetPathToTestFile("");
			string[] filesToDelete = Directory.GetFiles(path, "GRAPH_*.graph");
			for (int i = filesToDelete.Length - 1; i >= 0; i--)
			{
				File.Delete(filesToDelete[i]);
			}
		}

		[TestMethod]
		public void Dijkstra_Test()
		{
			Route actual;

			foreach (TestData data in TestDatas)
			{
				actual = Algorithm_Collection.GraphAlgorithm.Dijkstra.FindShortestPath(data.Graph, data.Start, data.End);

				Assert.AreEqual(actual.NodeList[0], data.End);
				Assert.AreEqual(actual.NodeList[actual.NodeList.Count - 1], data.Start);
				Assert.AreEqual(actual.Distance, data.End.DistanceToStartNode);
			}
		}

		[TestMethod]
		public void AStern_Test()
		{
			Route actual;

			foreach (TestData data in TestDatas)
			{
				actual = Algorithm_Collection.GraphAlgorithm.AStern.FindShortestPath(data.Graph, data.Start, data.End);

				Assert.AreEqual(actual.NodeList[0], data.End);
				Assert.AreEqual(actual.NodeList[actual.NodeList.Count - 1], data.Start);
				Assert.AreEqual(actual.Distance, data.End.DistanceToStartNode);
			}
		}

		[TestMethod]
		public void ExportTofile_Test()
		{
			foreach (TestData data in TestDatas)
			{
				string path = GetPathToTestFile("GRAPH_" + GetRandomString() + ".graph");
				string fileContent = GraphLogic.ExportGraphToFile(data.Graph, path);
				string actualHash = GetHashForFile(path);

				Assert.AreEqual(data.Hash, actualHash);
			}
		}

		[TestMethod]
		public void ImportFromFile_Test()
		{
			foreach (TestData data in TestDatas)
			{
				string path = data.Filename;
				Graph actual = GraphLogic.ImportGraphFromFile(path);

				Assert.AreEqual(data.Graph, actual);
			}
		}

		#region Helperfunctions

		public static string GetHashForFile(string file)
		{
			using (var md5 = MD5.Create())
			{
				using (var stream = File.OpenRead(file))
				{
					return Convert.ToBase64String(md5.ComputeHash(stream));
				}
			}
		}

		private static string GetPathToTestFile(string file)
		{
			return Path.Combine(PathToProject, cPathToTestData, file);
		}

		/// <summary>
		/// Generate a graph from a .graph file
		/// </summary>
		/// <param name="pathToGraphFile">Path to .graph file</param>
		private static Graph ImportGraphFromFile(string pathToGraphFile)
		{
			if (String.IsNullOrEmpty(pathToGraphFile))
				return null;

			if (!File.Exists(pathToGraphFile))
				return null;

			List<Node> Nodes = new List<Node>();
			List<Edge> Edges = new List<Edge>();

			bool nodeInLine = false;
			bool edgeInLine = false;
			string[] allLines = File.ReadAllLines(pathToGraphFile);
			foreach (string line in allLines)
			{
				line.Trim();

				if (line.Equals("<Nodes>"))
				{
					nodeInLine = true;
					edgeInLine = false;
					continue;
				}
				if (line.Equals("<Edges>"))
				{
					nodeInLine = false;
					edgeInLine = true;
					continue;
				}

				if (nodeInLine)
				{
					try
					{
						string name = line.Substring(0, line.IndexOf('[') - 1);
						string x = line.Substring(line.IndexOf('[') + 1, line.IndexOf(',') - 1 - line.IndexOf('['));
						string y = line.Substring(line.IndexOf(',') + 1, line.IndexOf(']') - 1 - line.IndexOf(','));

						//Node erzeugen
						Node n = new Node(name, new Point(Int32.Parse(x), Int32.Parse(y)));
						if (n != null)
							Nodes.Add(n);
					}
					catch (Exception ex)
					{
						Console.Write(ex);
					}
				}
				else if (edgeInLine)
				{
					try
					{
						string startNodeName = line.Substring(0, line.IndexOf('-'));
						string endNodeName = line.Substring(line.IndexOf('-') + 1, line.IndexOf('(') - 2 - line.IndexOf('-'));
						string weigth = line.Substring(line.IndexOf('(') + 1, line.IndexOf(')') - 1 - line.IndexOf('('));

						//find Node Objekts
						Node startNode = Nodes.Find(n => n.Name.Equals(startNodeName));
						Node endNode = Nodes.Find(n => n.Name.Equals(endNodeName));
						//Edge Objekt
						if (startNode != null && endNode != null)
						{
							Edge e = new Edge(startNode, endNode, double.Parse(weigth));
							if (e != null)
								Edges.Add(e);
						}
					}
					catch (Exception ex)
					{
						Console.Write(ex);
					}
				}
			}

			return new Graph(Nodes, Edges);
		}

		private static string GetRandomString()
		{
			return Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
		}
		#endregion
	}
}
