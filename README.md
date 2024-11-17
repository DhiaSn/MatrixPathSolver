# MatrixPathSolver

MatrixPathSolver is a C# project that implements the **A* (A-Star)** algorithm for pathfinding in a grid. It calculates the shortest path from a starting point to an endpoint, considering obstacles within the grid.

---

## Features

- **A* Algorithm Implementation**: Uses the A* algorithm for efficient pathfinding.
- **Obstacle Support**: Allows for dynamic placement of obstacles in the grid.
- **Path Reconstruction**: Reconstructs the shortest path using parent-child relationships.
- **Singleton Pattern**: Ensures a single instance of the FinderService for efficiency.

---

## How It Works

The **A* Algorithm** is a heuristic search algorithm that combines:
- **GCost**: The cost from the starting point to the current point.
- **HCost**: A heuristic estimate of the distance from the current point to the endpoint.
- **FCost**: The total cost, calculated as `FCost = GCost + HCost`.

The algorithm prioritizes exploring the nodes with the lowest FCost, ensuring it finds the shortest path efficiently.

### Steps:
1. The algorithm starts by adding the initial node to an open list.
2. It iteratively selects the node with the smallest FCost.
3. Each neighboring node is evaluated based on its cost, and the shortest path to that node is updated.
4. The process continues until the endpoint is reached, or all possible paths are exhausted.
5. The algorithm then reconstructs the path from the endpoint back to the start by tracing parent relationships.

---

## Project Structure

- **Models**: Defines the `Node` class, which represents individual points in the grid, including their costs (GCost, HCost, FCost) and their parent for backtracking the path.
- **Services**: Contains the `FinderService`, a singleton responsible for implementing the A* algorithm. This service handles the heuristic calculations, pathfinding logic, and obstacle integration.
- **Main Program**: A demonstration of how to set up the grid, define the start and end points, specify obstacles, and execute the pathfinding process.

---

## How to Run

1. Clone the repository to your local machine.
2. Open the solution in your preferred IDE or code editor.
3. Define the grid, start point, endpoint, and obstacles in the main program file.
4. Run the program to calculate and display the shortest path.

---

## Example Usage

When executed, the program processes the grid, avoiding obstacles, and outputs the shortest path between the starting point and the endpoint. If no path exists, it indicates that no valid path was found.

---

## Use Cases

1. **Robotics Navigation**: 
   The A* algorithm can guide robots to move through complex environments with obstacles.

2. **Game Development**:
   Game characters or entities can use this algorithm for efficient pathfinding within a game world.

3. **Transportation and Logistics**:
   Optimize routes for vehicles in grid-based systems like warehouses or delivery networks.

4. **Maze Solving**:
   Solve complex mazes or puzzles by finding the shortest path between two points.
