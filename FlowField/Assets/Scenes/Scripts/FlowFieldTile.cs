using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFieldTile {

    private bool isBlocked;
    private Vector2Int gridPos;
    private int weight;

    public FlowFieldTile(int x, int y) {
        this.weight = -1;
        this.gridPos = new Vector2Int(x, y);
    }
 




    public void setIsBlocked() {
        this.isBlocked = true;
    }

    public bool getIsBlocked() {
        return this.isBlocked;
    }

    public void setgridPos(Vector2Int vec) {
        this.gridPos = vec;
    }

    public Vector2Int getVector2d() {
        return this.gridPos;
    }

    public void setWeight(int i) {
        this.weight = i;
    }

    public int getWeight() {
        return this.weight;
    }
}
