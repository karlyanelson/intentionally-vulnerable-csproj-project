using System;
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
            throw new NotImplementedException();
        }
    }

}
