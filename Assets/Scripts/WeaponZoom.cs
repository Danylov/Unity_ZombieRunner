using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera fpsCamera;
    [SerializeField] private float zoomedOutFOV = 60f;
    [SerializeField] private float zoomedInFOV = 20f;

    private bool zoomedInToggle = false; 

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false) fpsCamera.fieldOfView = zoomedInFOV;
            else fpsCamera.fieldOfView = zoomedOutFOV;
            zoomedInToggle = !zoomedInToggle;
        }
    }
}
