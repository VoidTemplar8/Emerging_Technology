using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReset : MonoBehaviour
{
    public float resetY = -10f; // The Y position below which the object will be reset

    private Vector3 initialPosition; // The initial position of the object

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < resetY)
        {
            ResetObjectPosition();
        }
    }

    void ResetObjectPosition()
    {
        transform.position = initialPosition;
    }
}
