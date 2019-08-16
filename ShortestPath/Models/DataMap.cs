using System;
using System.Collections.Generic;

namespace ShortestPath.Models
{
    public class DataMap
    {
        public string MapId;
        public float[,] AdjacencyMatrix;
        public IList<string> Keys;
    }
}
