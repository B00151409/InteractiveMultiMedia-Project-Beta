using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset = new Vector3(10.0f, 0f,0f); // Adjust this offset as needed

    void Update()
    {
        if (playerTransform != null)
        {
            // Update the camera's position to follow the player with the specified offset
            transform.position = playerTransform.position + offset;
        }
    }
}