using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentNavigation : MonoBehaviour
{
    public WorldGrid worldGrid;
    public Transform agentPosition;
    public Rigidbody rb;
    public float force =1.0f;

    private void Start() {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2Int vec = worldGrid.NodeFromWorldPoint(agentPosition.position).getFlowFieldVector();
        Vector3 moveDir = new Vector3(vec.x, 0, vec.y);
        //Debug.Log(vec.x + "," + vec.y);
        //rb.AddForce(moveDir * force * Time.deltaTime);
        
        transform.position += moveDir * force * Time.deltaTime;

    }
}
