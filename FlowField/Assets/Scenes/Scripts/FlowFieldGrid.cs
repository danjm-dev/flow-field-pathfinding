using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlowFieldGrid {

    public static Vector2Int[,] generateFlowField(Vector2Int gridSize, DijkstraTile[,] dijkstraGrid) {

        //Generate an empty grid, set all places as Vector2.zero, which will stand for no good direction
        Vector2Int[,] flowField = new Vector2Int[gridSize.x, gridSize.y];
        for (int x = 0; x < gridSize.x; x++) {
            for (int y = 0; y < gridSize.y; y++) {
                flowField[x, y] = Vector2Int.zero;//may need to construct dynamic vector
            }
        }

        //for each grid square
        for (int x = 0; x < gridSize.x; x++) {
            for (int y = 0; y < gridSize.y; y++) {

                //skip current iteration if index has obsticle
                if (dijkstraGrid[x, y].getWeight() != int.MaxValue) {

                    Vector2Int pos = new Vector2Int(x, y);
                    List<Vector2Int> neighbours = allNeighboursOf(pos, gridSize);

                    //Go through all neighbours and find the one with the lowest distance
                    Vector2Int min = Vector2Int.zero;//this may be incorrect
                    bool minNotNull = false;
                    int minDist = 0;
                    for (int i = 0; i < neighbours.Count; i++) {
                        Vector2Int n = neighbours[i];
                        int dist = dijkstraGrid[n.x, n.y].getWeight() - dijkstraGrid[pos.x, pos.y].getWeight();
                        if (dist < minDist) {
                            min = n;
                            minNotNull = true;
                            minDist = dist;
                        }
                    }

                    //If we found a valid neighbour, point in its direction
                    if (minNotNull) {//potential problem
                        flowField[x, y] = min - pos;
                    }
                }
            }
        }
        return flowField;
    }


    private static List<Vector2Int> allNeighboursOf(Vector2Int v, Vector2Int gridSize) {
        List<Vector2Int> res = new List<Vector2Int>();
        for (int dx = -1; dx <= 1; dx++) {
            for (int dy = -1; dy <= 1; dy++) {
                int x = v.x + dx;
                int y = v.y + dy;
                //All neighbours on the grid that aren't ourself
                if (x >= 0 && y >= 0 && x < gridSize.x && y < gridSize.y && !(dx == 0 && dy == 0)) {
                    res.Add(new Vector2Int(x, y));
                }
            }
        }
        return res;
    }



}
