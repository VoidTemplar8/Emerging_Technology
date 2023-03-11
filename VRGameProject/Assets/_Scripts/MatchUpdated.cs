using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MatchUpdated : MonoBehaviour
{
    public string targetTag; // the tag of the gameobjects we want to destroy upon collision
   
    private void OnCollisionEnter(Collision collision)
    {
        // check if the collision involves the target tag
        if (collision.gameObject.CompareTag(targetTag))
        {
            // check if the collided objects are being held by controllers
            OVRGrabbable grabbable1 = collision.gameObject.GetComponent<OVRGrabbable>();
            OVRGrabbable grabbable2 = collision.contacts[0].otherCollider.gameObject.GetComponent<OVRGrabbable>();

            if (grabbable1 != null && grabbable1.grabbedBy != null && grabbable1.isGrabbed && grabbable2 != null && grabbable2.grabbedBy != null && grabbable2.isGrabbed)
            {
                // if both collided objects are being held by controllers, destroy them
                gameObject.SetActive(false);
                
                Destroy(collision.gameObject);
                Destroy(collision.contacts[0].otherCollider.gameObject);
                
            }
        }
    }
}
