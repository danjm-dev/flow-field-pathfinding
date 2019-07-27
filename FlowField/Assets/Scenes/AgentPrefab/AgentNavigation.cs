using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentNavigation : MonoBehaviour
{
    public WorldGrid worldGrid;
    public Transform agentPosition;
    public Rigidbody rb;
    public float force =1.0f;

    private DijkstraTile lastValidTile;

    private void Start() {
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        //this.lastValidTile = worldGrid.NodeFromWorldPoint(agentPosition.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        DijkstraTile currentTile = worldGrid.NodeFromWorldPoint(agentPosition.position);
        if(this.lastValidTile == null) { this.lastValidTile = currentTile; }
        if (currentTile.getFlowFieldVector().Equals(Vector2Int.zero)) {

            
            Vector2Int flowVector = this.lastValidTile.getVector2d() - currentTile.getVector2d();
            Vector3 moveDir = new Vector3(flowVector.x, 0, flowVector.y).normalized;
            rb.AddForce(moveDir * Time.deltaTime * force, ForceMode.Force);
            //transform.position += moveDir * Time.deltaTime;

        }
        else {
            this.lastValidTile = currentTile;
            Vector2Int flowVector = currentTile.getFlowFieldVector();
            Vector3 moveDir = new Vector3(flowVector.x, 0, flowVector.y).normalized;
            rb.AddForce(moveDir * Time.deltaTime * force, ForceMode.Force);

        }
    }
}
