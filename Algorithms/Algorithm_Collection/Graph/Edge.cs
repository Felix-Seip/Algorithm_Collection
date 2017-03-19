using Math_Collection.LinearAlgebra.Vectors;
using System;

namespace Algorithm_Collection.Graph
{
	public class Edge
	{
		private double _weight;
		/// <summary>
		/// Gets or Sets the weight of the edge
		/// (Representing the distance)
		/// </summary>
		public double Weight
		{
			get { return _weight; }
			set { _weight = value; }
		}

		private Node _start;
		/// <summary>
		/// Gets or Sets the start node for the edge
		/// </summary>
		public Node Start
		{
			get { return _start; }
			set { _start = value; }
		}

		private Node _end;
		/// <summary>
		/// Gets or Sets the end node for the edge
		/// </summary>
		public Node End
		{
			get { return _end; }
			set { _end = value; }
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="start">Start node of the edge</param>
		/// <param name="end">End node of the edge</param>
		public Edge(Node start, Node end)
		{
			Start = start;
			End = end;
			Weight = CalcDistanceForEdge();
			start.AddEdge(this);
			end.AddEdge(this);
		}

		/// <summary>
		/// Constuctor
		/// </summary>
		/// <param name="start">Start node of the edge</param>
		/// <param name="end">End node of the edge</param>
		/// <param name="weigth">Weight of the edge</param>
		public Edge(Node start, Node end, double weigth) : this(start, end)
		{
			Weight = weigth;
		}

		/// <summary>
		/// Calculates the weight for the edge
		/// </summary>
		/// <returns></returns>
		private double CalcDistanceForEdge()
		{
			Vector vectorBeetweenNodes = new Vector(new double[] { End.Location.X - Start.Location.X, End.Location.Y - Start.Location.Y });
			return Math.Round(vectorBeetweenNodes.Magnitude, 3);
		}

		/// <summary>
		/// Gets the string representation for the edge
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Start.Name + "-" + End.Name + " (" + (int)Weight + ")";
		}
	}
}
