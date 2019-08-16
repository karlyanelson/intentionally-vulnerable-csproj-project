using System;
using System.Linq;
using ShortestPath.Models;

namespace ShortestPath.Servies
{
    public interface IAdjacencyMatrix
    {
        float[,] CreateMatrix(ViewNodes viewNodes);
    }
    public class AdjacencyMatrix : IAdjacencyMatrix
    {
        public AdjacencyMatrix()
        {
        }

        public float[,] CreateMatrix(ViewNodes viewNodes)
        {
            var nodes = viewNodes.Nodes;
            var keys = nodes.Select(x => x.Id).ToList();

            var ct = nodes.Count;
            float[,] matrix = new float[ct, ct];

            for (int i = 0; i < ct; i++)
            {
                for (int j = 0; j < ct; j++)
                {
                    matrix[i, j] = 0;
                }

            }


            for (int i = 0; i < ct; i++)
            {
                var node = nodes[i];
                foreach(var arc in node.Arc)
                {
                    matrix[i, keys.IndexOf(arc.Key)] = arc.Value;
                }

            }


            return matrix;
        }
    }

}
