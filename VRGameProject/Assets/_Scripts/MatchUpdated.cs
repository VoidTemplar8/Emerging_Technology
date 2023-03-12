using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MatchUpdated : MonoBehaviour
{
    public string targetTag; // the tag of the gameobjects we want to destroy upon collision
    public AudioClip CorrectMatch;
   
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
                //gameObject.SetActive(false);

                // play the audio clip
                //AudioSource audioSource = GetComponent<AudioSource>();
                //audioSource.clip = CorrectMatch;
                //audioSource.Play();

                Destroy(collision.gameObject);
                Destroy(collision.contacts[0].otherCollider.gameObject);

               
               // Invoke("PlayDelayed", 2f);
            }
        }
    }

    //private void PlayDelayed()
    //{
    //    GetComponent<AudioSource>().Play();
    //}
}
