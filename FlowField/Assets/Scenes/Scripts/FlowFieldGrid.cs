using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFieldGrid : MonoBehaviour {

    public int gridSizeX;
    public int gridSizeY;
    public Vector2 destination;


    //private int[] arrr = new int[7];




    // Start is called before the first frame update
    void Start() {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

    }

    // Update is called once per frame
    void Update() {
        
    }









    private void generateDijkstraGrid(int gridWidth, int gridHeight, ArrayList walls) {
        //Generate an empty grid, set all places as weight null, which will stand for unvisited
        FlowFieldTile[,] dijkstraGrid = new FlowFieldTile[gridWidth, gridHeight];
        for (int x = 0; x < gridWidth; x++) {
            for (int y = 0; y < gridHeight; y++) {
                dijkstraGrid[x,y] = new FlowFieldTile();//weight null
            }
        }

        //Set all places where obstacles are as being weight MAXINT, which will stand for not able to go here
        foreach (Vector2Int element in walls){
            dijkstraGrid[element.x, element.y].setIsBlocked();//Number.MAX_VALUE;
        }

        //flood fill out from the end point
        var pathEnd = destination.round();
        pathEnd.distance = 0;
        dijkstraGrid[pathEnd.x][pathEnd.y] = 0;

        var toVisit = [pathEnd];

        //for each node we need to visit, starting with the pathEnd
        for (i = 0; i < toVisit.length; i++) {
            var neighbours = straightNeighboursOf(toVisit[i]);

            //for each neighbour of this node (only straight line neighbours, not diagonals)
            for (var j = 0; j < neighbours.length; j++) {
                var n = neighbours[j];

                //We will only ever visit every node once as we are always visiting nodes in the most efficient order
                if (dijkstraGrid[n.x][n.y] === null) {
                    n.distance = toVisit[i].distance + 1;
                    dijkstraGrid[n.x][n.y] = n.distance;
                    toVisit.push(n);
                }
            }
        }
    }






}
