using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraTile {

    private Vector2Int gridPos;
    private int weight;
    Vector3 worldPosition;
    Vector2Int FlowFieldVector;

    public DijkstraTile(Vector2Int gridPos, Vector3 worldPosition) {
        this.weight = -1;
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

    public Vector3 getWorldPosition() {
        return this.worldPosition;
    }

    public void setFlowFieldVector(Vector2Int v) {
        this.FlowFieldVector = v;
    }

    public Vector2Int getFlowFieldVector() {
        return FlowFieldVector;
    }
}
