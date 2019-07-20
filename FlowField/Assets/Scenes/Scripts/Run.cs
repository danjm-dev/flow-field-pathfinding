using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    private Vector2Int gridSize = new Vector2Int(5,10);
    // Start is called before the first frame update
    void Start() {
        DijkstraTile[,] dijkstraGrid = DijkstraGrid.generateDijkstraGrid(gridSize, getTarget(), getWalls());
        Vector2Int[,] flowFieldGrid = FlowFieldGrid.generateFlowField(gridSize, dijkstraGrid);


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

    private Vector2Int getTarget() {
        return new Vector2Int(3, 3);
    }

    private List<Vector2Int> getWalls() {
        List<Vector2Int> walls = new List<Vector2Int>();
        walls.Add(new Vector2Int(0, 2));
        walls.Add(new Vector2Int(4, 3));
        return walls;
    }
}
