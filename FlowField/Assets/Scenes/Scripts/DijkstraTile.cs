using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraTile {

    private Vector2Int gridPos;
    private int weight;

    public DijkstraTile(Vector2Int gridPos) {
        this.weight = -1;
        this.gridPos = gridPos;
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
