using MatrixPathSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPathSolver.Services
{
    public class FinderService
    {
        #region Instance Management
        private static FinderService? instance;
        public static FinderService Instance
        {
            get
            {
                instance ??= new FinderService();
                return instance;
            }
        }
        private FinderService() { }

        #endregion

        #region Methods
        /*
         * A Algorithm*:
         *   Calculates GCost (distance from start), HCost (heuristic to end), and FCost (total cost).
         *   Chooses the node with the lowest FCost at each step.
         * Path Reconstruction:
         *   Traces back from the end node to the start node using the Parent property.
         */
        public List<(int, int)> FindPath(int[,] matrix, (int X, int Y) start, (int X, int Y) end, List<(int X, int Y)> obstacles)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Mark obstacles in the matrix
            foreach (var obstacle in obstacles)
            {
                matrix[obstacle.X, obstacle.Y] = 1;
            }

            var openList = new List<Node>();
            var closedList = new HashSet<(int, int)>();

            Node startNode = new Node { X = start.X, Y = start.Y, GCost = 0, HCost = GetHeuristic(start, end) };
            openList.Add(startNode);

            while (openList.Count > 0)
            {
                // Get node with the lowest F cost
                var currentNode = openList[0];
                foreach (var node in openList)
                {
                    if (node.FCost < currentNode.FCost || (node.FCost == currentNode.FCost && node.HCost < currentNode.HCost))
                        currentNode = node;
                }

                openList.Remove(currentNode);
                closedList.Add((currentNode.X, currentNode.Y));

                // Check if we reached the end
                if (currentNode.X == end.X && currentNode.Y == end.Y)
                    return ReconstructPath(currentNode);

                // Explore neighbors
                foreach (var neighbor in GetNeighbors(currentNode, rows, cols))
                {
                    if (closedList.Contains((neighbor.X, neighbor.Y)) || matrix[neighbor.X, neighbor.Y] == 1)
                        continue;

                    double tentativeGCost = currentNode.GCost + 1;

                    var openNode = openList.Find(n => n.X == neighbor.X && n.Y == neighbor.Y);
                    if (openNode == null)
                    {
                        neighbor.GCost = tentativeGCost;
                        neighbor.HCost = GetHeuristic((neighbor.X, neighbor.Y), end);
                        neighbor.Parent = currentNode;
                        openList.Add(neighbor);
                    }
                    else if (tentativeGCost < openNode.GCost)
                    {
                        openNode.GCost = tentativeGCost;
                        openNode.Parent = currentNode;
                    }
                }
            }

            // No path found
            return null;
        }

        public double GetHeuristic((int X, int Y) point, (int X, int Y) end)
        {
            // Using Manhattan distance as heuristic
            return Math.Abs(point.X - end.X) + Math.Abs(point.Y - end.Y);
        }

        public List<Node> GetNeighbors(Node node, int rows, int cols)
        {
            var neighbors = new List<Node>();

            var directions = new (int X, int Y)[]
            {
            (-1, 0), (1, 0), (0, -1), (0, 1) // Up, Down, Left, Right
            };

            foreach (var dir in directions)
            {
                int newX = node.X + dir.X;
                int newY = node.Y + dir.Y;

                if (newX >= 0 && newX < rows && newY >= 0 && newY < cols)
                {
                    neighbors.Add(new Node { X = newX, Y = newY });
                }
            }

            return neighbors;
        }

        public List<(int, int)> ReconstructPath(Node endNode)
        {
            var path = new List<(int, int)>();
            var currentNode = endNode;

            while (currentNode != null)
            {
                path.Add((currentNode.X, currentNode.Y));
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            return path;
        }
        #endregion
    }
}
