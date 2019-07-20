using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    private int gridSizeX = 5;
    private int gridSizeY = 10;
    // Start is called before the first frame update
    void Start() {
        DijkstraTile[,] arr = DijkstraGrid.generateDijkstraGrid(gridSizeX, gridSizeY, getTarget(), getWalls());

        string s = "";
        for (int i = 0; i < gridSizeX; i++) {
            for (int y = 0; y < gridSizeY; y++) {

                if (arr[i, y].getWeight() == int.MaxValue) {
                    s = s + "X";
                }
                else {
                    s = s + arr[i, y].getWeight().ToString();
                }
            }
            s = s + "\n";
        }
        Debug.Log(s);
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
