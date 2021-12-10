using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script applies a spinning effect to a game object

public class SpinningObject : MonoBehaviour
{
    public float rotateSpeed = 50f;
    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    // Spin the object at the specified speed
    void Rotate()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }
}
