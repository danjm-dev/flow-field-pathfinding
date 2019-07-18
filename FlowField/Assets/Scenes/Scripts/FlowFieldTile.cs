using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFieldTile : MonoBehaviour
{
    private bool isBlocked;

    public void setIsBlocked() {
        isBlocked = true;
    }

    public bool getIsBlocked() {
        return isBlocked;
    }
}
