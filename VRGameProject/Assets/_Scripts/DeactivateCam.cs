using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateCam : MonoBehaviour
{


    public OVRInput.Controller controller;

    private new Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, controller))
        {
            camera.enabled = false;
        }
    }
}
