using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This controls the Enemy health display

public class EnemyHUDBillboard : MonoBehaviour
{

    Transform cam;

    // Update is called once per frame
    void Update()
    {
        // Have the healthbar always look at the camera
        cam = GameObject.FindWithTag("MainCamera").transform;

        transform.LookAt(transform.position + cam.forward);
        
    }
}
