using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedCanvasControl : MonoBehaviour
{
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    
    void Update()
    {
        transform.LookAt(mainCamera.transform);
    }
}
