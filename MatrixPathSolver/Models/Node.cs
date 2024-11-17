namespace MatrixPathSolver.Models
{
    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double GCost { get; set; } // Distance from start
        public double HCost { get; set; } // Heuristic distance to end
        public double FCost => GCost + HCost; // Total cost
        public Node? Parent { get; set; } // To trace the path
    }

}
