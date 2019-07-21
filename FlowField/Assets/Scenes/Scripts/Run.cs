using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public Vector2Int gridSize;
    public Vector2Int target;
    public List<Vector2Int> walls;
    

    // Start is called before the first frame update
    void Start() {
        if (checkInputs()) { 

            DijkstraTile[,] dijkstraGrid = DijkstraGrid.generateDijkstraGrid(gridSize, target, walls);
            Vector2Int[,] flowFieldGrid = FlowFieldGrid.generateFlowField(gridSize, dijkstraGrid);
            printStuff(gridSize, dijkstraGrid, flowFieldGrid);
        }
    }

    private static bool checkInputs() {
        return true;
    }

    private static void printStuff(Vector2Int gridSize, DijkstraTile[,] dijkstraGrid, Vector2Int[,] flowFieldGrid) {

        string s = "DijstraGrid\n";
        for (int i = 0; i < gridSize.x; i++) {
            for (int y = 0; y < gridSize.y; y++) {
                if (dijkstraGrid[i, y].getWeight() == int.MaxValue) {
                    s = s + "X";
                }
                else {
                    s = s + dijkstraGrid[i, y].getWeight().ToString();
                }
            }
            s = s + "\n";
        }
        Debug.Log(s);

        string st = "FlowFieldGrid\n";
        for (int i = 0; i < gridSize.x; i++) {
            for (int y = 0; y < gridSize.y; y++) {
                st = st + flowFieldGrid[i, y];
            }
            st = st + "\n";
        }
        Debug.Log(st);

    }



}
