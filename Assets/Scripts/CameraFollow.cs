using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Target object position
    [Header("Target Object")]
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        // If target position on the y axis is greater
        // than the camera position
        if (target.position.y > transform.position.y)
        {
            // The camera will follow the target's position
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.x);
        }
    }
}
