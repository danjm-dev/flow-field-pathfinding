using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentNavigation : MonoBehaviour
{
    public WorldGrid worldGrid;
    public Transform agentPosition;
    public Rigidbody rb;
    public float force =1.0f;
    private Vector3 backupMovement = Vector3.zero;
    private void Start() {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2Int vec = worldGrid.NodeFromWorldPoint(agentPosition.position).getFlowFieldVector();
        Vector3 moveDir = new Vector3(vec.x, 0, vec.y).normalized;

        //if (moveDir.Equals(Vector3.zero)) {
        //    if (this.backupMovement.Equals(Vector3.zero)) {
        //        Debug.Log("Agent started on invalid tile");
        //    }
        //    rb.AddForce(-this.backupMovement * Time.deltaTime * force, ForceMode.Force);
        //}
        //else {
        //    this.backupMovement = moveDir;
        //    rb.AddForce(moveDir * Time.deltaTime * force, ForceMode.Force);
        //}

        transform.position += moveDir * force * Time.deltaTime;

    }
}
