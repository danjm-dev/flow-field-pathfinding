using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraTile {

    private Vector2Int gridPos;
    private int weight;
    private bool isWall;
    Vector3 worldPosition;

    public DijkstraTile(Vector2Int gridPos, Vector3 worldPosition, bool isWall) {
        //this.weight = weight;
        this.isWall = isWall;
        this.gridPos = gridPos;
        this.worldPosition = worldPosition;
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

    public bool getIsWall() {
        return this.isWall;
    }

    public Vector3 getWorldPosition() {
        return this.worldPosition;
    }
}
