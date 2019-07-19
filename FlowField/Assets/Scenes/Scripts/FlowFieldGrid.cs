using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFieldGrid : MonoBehaviour {

    public int gridSizeX;
    public int gridSizeY;
    public FlowFieldTile target;
    public List<Vector2Int> walls;
    private FlowFieldTile[,] weightArray;


    // Start is called before the first frame update
    public FlowFieldGrid() {
        this.gridSizeX = 10;
        this.gridSizeY = 10;
        //GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        this.target = new FlowFieldTile(5, 3);
        this.walls = new List<Vector2Int>();
        this.walls.Add(new Vector2Int(2,4));
        this.weightArray = generateDijkstraGrid(this.gridSizeX, this.gridSizeY, this.walls);
    }



    private FlowFieldTile[,] generateDijkstraGrid(int gridWidth, int gridHeight, List<Vector2Int> walls/*ArrayList of vector2dInt*/) {
        //Generate an empty grid, set all places as weight -1, which will stand for unvisited
        FlowFieldTile[,] dijkstraGrid = new FlowFieldTile[gridWidth, gridHeight];
        for (int x = 0; x < gridWidth; x++) {
            for (int y = 0; y < gridHeight; y++) {
                dijkstraGrid[x,y] = new FlowFieldTile(x, y);
            }
        }

        //Set all places where obstacles are as being weight MaxValue, which will stand for not able to go here
        foreach (Vector2Int element in walls){
            dijkstraGrid[element.x, element.y].setWeight(int.MaxValue);
        }

        //flood fill out from the end point
        FlowFieldTile destination = this.target;
        destination.setWeight(0);
        dijkstraGrid[destination.getVector2d().x, destination.getVector2d().y].setWeight(0);

        List<FlowFieldTile> toVisit = new List<FlowFieldTile>();
        toVisit.Add(destination);//check this maybe!!!


        //for each node we need to visit, starting with the pathEnd
        //foreach (FlowFieldTile node in toVisit.ToArray()) {//fuck me
        for(int i =0; i<toVisit.Count; i++) {

            List<FlowFieldTile> neighbours = straightNeighboursOf(toVisit[i]);

            //for each neighbour of this node (only straight line neighbours, not diagonals)
            foreach (FlowFieldTile neighbour in neighbours) {

                //We will only ever visit every node once as we are always visiting nodes in the most efficient order
                if (dijkstraGrid[neighbour.getVector2d().x, neighbour.getVector2d().y].getWeight()==-1) {//if tile has not been visited
                    neighbour.setWeight(toVisit[i].getWeight() + 1);
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
