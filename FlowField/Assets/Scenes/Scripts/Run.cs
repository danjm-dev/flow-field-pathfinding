using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    private int gridSizeX = 5;
    private int gridSizeY = 10;
    // Start is called before the first frame update
    void Start() {
        DijkstraTile[,] dijkstraGrid = DijkstraGrid.generateDijkstraGrid(gridSizeX, gridSizeY, getTarget(), getWalls());
        Vector2Int[,] flowFieldGrid = FlowFieldGrid.generateFlowField(gridSizeX, gridSizeY, dijkstraGrid);



        string s = "DijstraGrid\n";
        for (int i = 0; i < gridSizeX; i++) {
            for (int y = 0; y < gridSizeY; y++) {

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
        for (int i = 0; i < gridSizeX; i++) {
            for (int y = 0; y < gridSizeY; y++) {

                    st = st + flowFieldGrid[i, y];
            }
            st = st + "\n";
        }
        Debug.Log(st);
    }




    private DijkstraTile getTarget() {
        return new DijkstraTile(3, 3);
    }

    private List<Vector2Int> getWalls() {
        List<Vector2Int> walls = new List<Vector2Int>();
        walls.Add(new Vector2Int(0, 2));
        walls.Add(new Vector2Int(4, 3));
        return walls;
    }
}
