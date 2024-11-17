using MatrixPathSolver.Services;

namespace MatrixPathSolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FinderService service = FinderService.Instance;

            /*
             * Matrix Representation:
             * --> 0 represents a free cell.
             * --> 1 represents an obstacle.
             */

            int[,] matrix = {
                                { 0, 0, 0, 0, 0 },
                                { 0, 1, 1, 0, 0 },
                                { 0, 0, 0, 1, 0 },
                                { 0, 1, 0, 0, 0 },
                                { 0, 0, 0, 0, 0 }
                            };

            var startPoint = (X: 0, Y: 0);

            var endPoint = (X: 4, Y: 4);
            
            var obstacles = new List<(int X, int Y)>
            {
                (1, 1), (1, 2), (2, 3), (3, 1)
            };

            List<(int, int)> path = service.FindPath(matrix, startPoint, endPoint, obstacles);

            if (path != null)
            {
                Console.WriteLine("Path found:");
                foreach (var point in path)
                    Console.WriteLine($"({point.Item1}, {point.Item2})");
            }
            else
            {
                Console.WriteLine("No path found!");
            }

        }
    }
}
