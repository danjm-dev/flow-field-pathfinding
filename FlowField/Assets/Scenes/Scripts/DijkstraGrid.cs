using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DijkstraGrid {


    public static DijkstraTile[,] generateDijkstraGrid(int gridSizeX, int gridSizeY, DijkstraTile target, List<Vector2Int> walls) {


        //Generate an empty grid, set all places as weight -1, which will stand for unvisited
        DijkstraTile[,] dijkstraGrid = new DijkstraTile[gridSizeX, gridSizeY];
        for (int x = 0; x < gridSizeX; x++) {
            for (int y = 0; y < gridSizeY; y++) {
                dijkstraGrid[x, y] = new DijkstraTile(x, y);
            }
        }

        //Set all places where obstacles are as being weight MaxValue, which will stand for not able to go here
        foreach (Vector2Int element in walls) {
            if (element.x < 0 || element.x > gridSizeX-1 || element.y<0 || element.y > gridSizeX-1) {
                Debug.Log("BAD WALL VECTOR- x: " + element.x + " y: " + element.y);
            }
            else {
                dijkstraGrid[element.x, element.y].setWeight(int.MaxValue);
            }
        }

        //flood fill out from the end point
        DijkstraTile destination = target;
        destination.setWeight(0);
        dijkstraGrid[destination.getVector2d().x, destination.getVector2d().y].setWeight(0);

        List<DijkstraTile> toVisit = new List<DijkstraTile>();
        toVisit.Add(destination);//check this maybe!!!


        //for each node we need to visit, starting with the pathEnd
        for (int i = 0; i < toVisit.Count; i++) {

            List<DijkstraTile> neighbours = straightNeighboursOf(toVisit[i], gridSizeX, gridSizeY);

            //for each neighbour of this node (only straight line neighbours, not diagonals)
            foreach (DijkstraTile neighbour in neighbours) {

                //We will only ever visit every node once as we are always visiting nodes in the most efficient order
                if (dijkstraGrid[neighbour.getVector2d().x, neighbour.getVector2d().y].getWeight() == -1) {//if tile has not been visited
                    neighbour.setWeight(toVisit[i].getWeight() + 1);
                    dijkstraGrid[neighbour.getVector2d().x, neighbour.getVector2d().y].setWeight(neighbour.getWeight());
                    toVisit.Add(neighbour);
                }
            }
        }
        return dijkstraGrid;
    }



    private static List<DijkstraTile> straightNeighboursOf(DijkstraTile tile, int gridSizeX, int gridSizeY) {
        List<DijkstraTile> neighbours = new List<DijkstraTile>();
        if (tile.getVector2d().x > 0) {
            neighbours.Add(new DijkstraTile(tile.getVector2d().x - 1, tile.getVector2d().y));
        }
        if (tile.getVector2d().y > 0) {
            neighbours.Add(new DijkstraTile(tile.getVector2d().x, tile.getVector2d().y - 1));
        }
        if (tile.getVector2d().x < gridSizeX - 1) {
            neighbours.Add(new DijkstraTile(tile.getVector2d().x + 1, tile.getVector2d().y));
        }
        if (tile.getVector2d().y < gridSizeY - 1) {
            neighbours.Add(new DijkstraTile(tile.getVector2d().x, tile.getVector2d().y + 1));
        }
        return neighbours;
    }
}
