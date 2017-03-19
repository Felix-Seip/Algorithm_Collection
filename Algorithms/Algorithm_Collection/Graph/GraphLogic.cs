using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Collection.Graph
{
	public static class GraphLogic
	{
		/// <summary>
		/// Saves the Graph object as a .graph file
		/// </summary>
		/// <param name="_graph">Graph object that should be saved</param>
		/// <param name="path">Path with filename where the file should be saved</param>
		public static void SaveGraphToFile(Graph g, string path)
		{
			if (g == null)
				return;

			if (string.IsNullOrEmpty(path))
				path = Path.GetRandomFileName() + ".graph";

			if (!Path.HasExtension(path))
				path = path + ".graph";


			string[] fileContent = new string[g.Nodes.Count + g.Edges.Count + 2];
			int index = 0;
			fileContent[index] = "<Nodes>";
			for (int i = 0; i < g.Nodes.Count; i++)
			{
				index++;
				fileContent[index] = g.Nodes[i].ToString();
			}
			index++;
			fileContent[index] = "<Edges>";
			for (int k = 0; k < g.Edges.Count; k++)
			{
				index++;
				fileContent[index] = g.Edges[k].ToString();
			}

			File.WriteAllLines(path, fileContent, Encoding.UTF8);
		}
	}
}
