using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFieldGrid {

    private int gridSizeX;
    private int gridSizeY;
    private FlowFieldTile target;


    //private int[] arrr = new int[7];




    // Start is called before the first frame update
    public FlowFieldGrid() {
        this.gridSizeX = 20;
        this.gridSizeY = 20;
        //GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        this.target = new FlowFieldTile(5, 5);
        FlowFieldTile[,] arr = generateDijkstraGrid(gridSizeX, gridSizeY, new List<Vector2Int>());


        for (int x = 0; x < gridSizeX; x++) {
            for (int y = 0; y < gridSizeY; y++) {
                Debug.Log(arr[x, y]);
            }
        }
        

    }











    private FlowFieldTile[,] generateDijkstraGrid(int gridWidth, int gridHeight, List<Vector2Int> walls/*ArrayList of vector2dInt*/) {
        //Generate an empty grid, set all places as weight -1, which will stand for unvisited
        FlowFieldTile[,] dijkstraGrid = new FlowFieldTile[gridWidth, gridHeight];
        for (int x = 0; x < gridWidth; x++) {
            for (int y = 0; y < gridHeight; y++) {
                dijkstraGrid[x,y] = new FlowFieldTile(x, y);
            }
        }

        //Set all places where obstacles are as being weight MAXINT, which will stand for not able to go here
        foreach (Vector2Int element in walls){
            dijkstraGrid[element.x, element.y].setIsBlocked();//Number.MAX_VALUE;
        }

        //flood fill out from the end point
        FlowFieldTile destination = this.target;
        destination.setWeight(0);
        dijkstraGrid[destination.getVector2d().x, destination.getVector2d().y].setWeight(0);

        List<FlowFieldTile> toVisit = new List<FlowFieldTile>();
        toVisit.Add(destination);//check this maybe!!!

        //for each node we need to visit, starting with the pathEnd
        foreach (FlowFieldTile node in toVisit) {
            List<FlowFieldTile> neighbours = straightNeighboursOf(node);

            //for each neighbour of this node (only straight line neighbours, not diagonals)
            foreach (FlowFieldTile neighbour in neighbours) {

                //We will only ever visit every node once as we are always visiting nodes in the most efficient order
                if (dijkstraGrid[neighbour.getVector2d().x, neighbour.getVector2d().y].getWeight()==-1) {//if tile has not been visited
                    neighbour.setWeight(node.getWeight() + 1);
                    dijkstraGrid[neighbour.getVector2d().x, neighbour.getVector2d().y].setWeight(neighbour.getWeight());
                    toVisit.Add(neighbour);
                }
            }
        }
        return dijkstraGrid;
    }



    private List<FlowFieldTile> straightNeighboursOf(FlowFieldTile tile) {
        List<FlowFieldTile> neighbours = new List<FlowFieldTile>();
        if (tile.getVector2d().x > 0) {
            neighbours.Add(new FlowFieldTile(tile.getVector2d().x - 1, tile.getVector2d().y));
        }
        if (tile.getVector2d().y > 0) {
            neighbours.Add(new FlowFieldTile(tile.getVector2d().x, tile.getVector2d().y - 1));
        }

        if (tile.getVector2d().x < gridSizeX - 1) {
            neighbours.Add(new FlowFieldTile(tile.getVector2d().x + 1, tile.getVector2d().y));
        }
        if (tile.getVector2d().y < gridSizeY - 1) {
            neighbours.Add(new FlowFieldTile(tile.getVector2d().x, tile.getVector2d().y + 1));
        }

        return neighbours;
    }






}
