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

The **A* Algorithm** combines:
- **GCost**: The cost from the start point to the current point.
- **HCost**: A heuristic estimate of the distance from the current point to the endpoint.
- **FCost**: The total cost (`FCost = GCost + HCost`).

The algorithm prioritizes nodes with the lowest FCost, ensuring optimal and efficient pathfinding.

### Steps:
1. Initialize open and closed lists.
2. Add the starting node to the open list.
3. While the open list is not empty:
   - Pick the node with the lowest FCost.
   - Check if it’s the endpoint. If yes, reconstruct the path.
   - Explore its neighbors and calculate their costs.
4. If the open list is empty and no path is found, return failure.

---
