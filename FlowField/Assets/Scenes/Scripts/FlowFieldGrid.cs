using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlowFieldGrid {

    public static DijkstraTile[,] generateFlowField(Vector2Int gridSize, DijkstraTile[,] grid) {

        //for each grid square
        for (int x = 0; x < gridSize.x; x++) {
            for (int y = 0; y < gridSize.y; y++) {

                //skip current iteration if index has obsticle
                if (grid[x, y].getWeight() != int.MaxValue) {

                    Vector2Int pos = new Vector2Int(x, y);
                    List<Vector2Int> neighbours = allNeighboursOf(pos, gridSize, grid);

                    //Go through all neighbours and find the one with the lowest distance
                    Vector2Int min = Vector2Int.zero;//this may be incorrect
                    bool minNotNull = false;
                    int minDist = 0;
                    for (int i = 0; i < neighbours.Count; i++) {
                        Vector2Int n = neighbours[i];
                        int dist = grid[n.x, n.y].getWeight() - grid[pos.x, pos.y].getWeight();
                        if (dist < minDist) {
                            min = n;
                            minNotNull = true;
                            minDist = dist;
                        }
                    }

                    //If we found a valid neighbour, point in its direction
                    if (minNotNull) {//potential problem
                        grid[x, y].setFlowFieldVector(min - pos);
                    }
                }
            }
        }
        return grid;
    }

    private static bool isValid(int x, int y, Vector2Int gridSize, DijkstraTile[,] grid) {
        return x >= 0 && y >= 0 && x < gridSize.x && y < gridSize.y && grid[x,y].getWeight() != int.MaxValue;
    }
    private static List<Vector2Int> allNeighboursOf(Vector2Int v, Vector2Int gridSize, DijkstraTile[,] grid) {
        List<Vector2Int> res = new List<Vector2Int>();
        int x = v.x;
        int y = v.y;
        bool up = isValid(x, y - 1, gridSize, grid), down = isValid(x, y + 1, gridSize, grid), left = isValid(x - 1, y, gridSize, grid), right = isValid(x + 1, y, gridSize, grid);

        //We test each straight direction, then subtest the next one clockwise

        if (left) {
            res.Add(new Vector2Int(x - 1, y));

            //left up
            if (up && isValid(x - 1, y - 1, gridSize, grid)) {
                res.Add(new Vector2Int(x - 1, y - 1));
            }
        }

        if (up) {
            res.Add(new Vector2Int(x, y - 1));

            //up right
            if (right && isValid(x + 1, y - 1, gridSize, grid)) {
                res.Add(new Vector2Int(x + 1, y - 1));
            }
        }

        if (right) {
            res.Add(new Vector2Int(x + 1, y));

            //right down
            if (down && isValid(x + 1, y + 1, gridSize, grid)) {
                res.Add(new Vector2Int(x + 1, y + 1));
            }
        }

        if (down) {
            res.Add(new Vector2Int(x, y + 1));

            //down left
            if (left && isValid(x - 1, y + 1, gridSize, grid)) {
                res.Add(new Vector2Int(x - 1, y + 1));
            }
        }
        return res;
    }




}
