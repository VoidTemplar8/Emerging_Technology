using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
    public string targetTag; // the tag of the gameobjects we want to destroy upon collision

    private void OnCollisionEnter(Collision collision)
    {
        // check if the collision involves the target tag
        if (collision.gameObject.CompareTag(targetTag))
        {
            // check if the collided object is being held by a controller
            OVRGrabbable grabbable = collision.gameObject.GetComponent<OVRGrabbable>();
            if (grabbable != null && grabbable.isGrabbed)
            {
                // if the collided object is being held, destroy it
                Destroy(collision.gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
