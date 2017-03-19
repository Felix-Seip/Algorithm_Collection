using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Algorithm_Collection.Graph
{
	public class Graph
	{
		private List<Node> _nodes;
		/// <summary>
		/// Gets or Sets the nodes for the graph
		/// </summary>
		public List<Node> Nodes
		{
			get { return _nodes; }
			set { _nodes = value; }
		}

		private List<Edge> _edges;
		/// <summary>
		/// Gets or Sets the edges for the graph
		/// </summary>
		public List<Edge> Edges
		{
			get { return _edges; }
			set { _edges = value; }
		}

		/// <summary>
		/// Standardkonstruktor
		/// </summary>
		public Graph()
		{
			Nodes = new List<Node>();
			Edges = new List<Edge>();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="nodes">Nodeliste</param>
		/// <param name="edges">Edgeliste</param>
		public Graph(List<Node> nodes, List<Edge> edges)
		{
			Nodes = nodes;
			Edges = edges;
		}

		/// <summary>
		/// Contructor with graph file
		/// </summary>
		/// <param name="pathToGraphFile">Path to the .graph file</param>
		public Graph(string pathToGraphFile)
		{
			if (String.IsNullOrEmpty(pathToGraphFile))
				return;

			if (!File.Exists(pathToGraphFile))
				return;

			Nodes = new List<Node>();
			Edges = new List<Edge>();
			GenerateNodesAndEdgesFromFile(pathToGraphFile);
		}

		/// <summary>
		/// Gets a node by the name
		/// </summary>
		/// <param name="name">Name of the node</param>
		/// <returns>Node if the name is contained in the graph. 
		/// Null if no node was found</returns>
		public Node FindNodeByName(string name)
		{
			foreach (Node n in Nodes)
			{
				if (n.Name.Equals(name.ToLower()))
					return n;
			}
			return null;
		}

		/// <summary>
		/// Gets all unvisited nodes
		/// </summary>
		/// <returns></returns>
		public List<Node> GetUnvisitedNodes()
		{
			if (Nodes == null)
				return null;

			return Nodes.FindAll(node => node.Visited == false);
		}

		/// <summary>
		/// Generate a graph from a .graph file
		/// </summary>
		/// <param name="pathToGraphFile">Path to .graph file</param>
		private void GenerateNodesAndEdgesFromFile(string pathToGraphFile)
		{
			if (String.IsNullOrEmpty(pathToGraphFile))
				return;

			if (!File.Exists(pathToGraphFile))
				return;

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
						Node startNode = FindNodeByName(startNodeName);
						Node endNode = FindNodeByName(endNodeName);
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
		}
		
		/// <summary>
		/// Gets the start or end node
		/// </summary>
		/// <param name="start">Bei true wird der Startknoten zurückgegeben.
		/// Bei false der Endknoten</param>
		/// <returns></returns>
		public Node GetMarkedNode(bool start = true)
		{
			List<Node> markedNodes = new List<Node>();
			foreach (Node n in Nodes)
			{
				if (n.Marked)
					markedNodes.Add(n);
			}

			if (markedNodes.Count == 0)
				return null;

			if (start)
				return markedNodes[0];

			return markedNodes[1];
		}

		/// <summary>
		/// Gets the string representation of the graph
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (Node n in Nodes)
			{
				sb.Append(n.ToString());
			}
			return sb.ToString();
		}
	}
}
