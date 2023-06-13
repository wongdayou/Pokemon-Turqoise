using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerPos;
    Vector3 coordinates = new Vector3(0,0,-1);

    // Update is called once per frame
    void Update()
    {
        coordinates.x = playerPos.position.x;
        coordinates.y = playerPos.position.y;
        transform.position = coordinates;
    }
}
