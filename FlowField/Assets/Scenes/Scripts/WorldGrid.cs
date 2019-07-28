using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrid : MonoBehaviour {

    public Transform StartPosition;//This is where the program will start the pathfinding from.
    public LayerMask WallMask;//This is the mask that the program will look for when trying to find obstructions to the path.
    public Vector2 vGridWorldSize;//A vector2 to store the width and height of the graph in world units.
    public float fNodeRadius;//This stores how big each square on the graph will be
    public float fDistanceBetweenNodes;//The distance that the squares will spawn from eachother.

    DijkstraTile[,] NodeArray;//The array of nodes that the A Star algorithm uses.

    float fNodeDiameter;//Twice the amount of the radius (Set in the start function)
    int iGridSizeX, iGridSizeY;//Size of the Grid in Array units.


    private void Start()//Ran once the program starts
    {
        fNodeDiameter = fNodeRadius * 2;//Double the radius to get diameter
        iGridSizeX = Mathf.RoundToInt(vGridWorldSize.x / fNodeDiameter);//Divide the grids world co-ordinates by the diameter to get the size of the graph in array units.
        iGridSizeY = Mathf.RoundToInt(vGridWorldSize.y / fNodeDiameter);//Divide the grids world co-ordinates by the diameter to get the size of the graph in array units.
        CreateGrid();//Draw the grid
        DijkstraTile[,] dijtraGrid = DijkstraGrid.generateDijkstraGrid(this.NodeArray, new Vector2Int(iGridSizeX, iGridSizeY), NodeFromWorldPoint(StartPosition.position));
        DijkstraTile[,] flowFieldGrid = FlowFieldGrid.generateFlowField(new Vector2Int(iGridSizeX, iGridSizeY), dijtraGrid);
    }

    void CreateGrid() {
        NodeArray = new DijkstraTile[iGridSizeX, iGridSizeY];//Declare the array of nodes.
        Vector3 bottomLeft = transform.position - Vector3.right * vGridWorldSize.x / 2 - Vector3.forward * vGridWorldSize.y / 2;//Get the real world position of the bottom left of the grid.
        for (int x = 0; x < iGridSizeX; x++)//Loop through the array of nodes.
        {
            for (int y = 0; y < iGridSizeY; y++)//Loop through the array of nodes
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * fNodeDiameter + fNodeRadius) + Vector3.forward * (y * fNodeDiameter + fNodeRadius);//Get the world co ordinates of the bottom left of the graph
                DijkstraTile tile = new DijkstraTile(new Vector2Int(x, y), worldPoint);

                if (Physics.CheckSphere(worldPoint, fNodeRadius, WallMask)) {
                    tile.setWeight(int.MaxValue);
                }
                NodeArray[x, y] = tile;//Create a new node in the array.
            }
        }
    }

    //Gets the closest node to the given world position.
    public DijkstraTile NodeFromWorldPoint(Vector3 a_vWorldPos) {
        float ixPos = ((a_vWorldPos.x + vGridWorldSize.x / 2) / vGridWorldSize.x);
        float iyPos = ((a_vWorldPos.z + vGridWorldSize.y / 2) / vGridWorldSize.y);

        ixPos = Mathf.Clamp01(ixPos);
        iyPos = Mathf.Clamp01(iyPos);

        int ix = Mathf.RoundToInt((iGridSizeX - 1) * ixPos);
        int iy = Mathf.RoundToInt((iGridSizeY - 1) * iyPos);

        return NodeArray[ix, iy];
    }


    //Function that draws the wireframe
    private void OnDrawGizmos() {

        Gizmos.DrawWireCube(transform.position, new Vector3(vGridWorldSize.x, 1, vGridWorldSize.y));//Draw a wire cube with the given dimensions from the Unity inspector

        if (NodeArray != null)//If the grid is not empty
        {
            foreach (DijkstraTile n in NodeArray)//Loop through every node in the grid
            {
                if (n.getWeight() == int.MaxValue)//If the current node is a wall node
                {
                    Gizmos.color = Color.magenta;//Set the color of the node
                }
                else {
                    Gizmos.color = Color.blue;//Set the color of the node
                }
                Gizmos.DrawCube(n.getWorldPosition(), new Vector3(1,0,1) * (fNodeDiameter - fDistanceBetweenNodes));//Draw the node at the position of the node.
            }
        }
    }
}