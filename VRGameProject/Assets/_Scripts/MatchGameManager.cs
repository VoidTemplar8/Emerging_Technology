using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchGameManager : MonoBehaviour
{
    public string[] targetTags;
    public AudioClip correctMatch;
    //public AudioClip objectFeedback1;
    //public AudioClip objectFeedback2;

    private void Start()
    {
     

    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        foreach (string tag in targetTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                OVRGrabbable grabbable1 = collision.gameObject.GetComponent<OVRGrabbable>();
                OVRGrabbable grabbable2 = collision.gameObject.GetComponent<OVRGrabbable>();

                if (grabbable1 != null && grabbable1.isGrabbed && grabbable2 != null && grabbable2.isGrabbed)
                {
                    audioSource.clip = correctMatch;
                    audioSource.Play();
                    Destroy(collision.gameObject);
                    //Destroy(collision.contacts[0].otherCollider.gameObject);
                    
                    Destroy(this.gameObject);
                    GameObject.Find("GameManager").GetComponent<GameManager>().AddToCount();
                }
                

                break; // exit the loop if a tag match is found
            }
        }
    }

    //Update To Do: Play different audio when object is detected.
    private void OnTriggerEnter(Collider other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        OVRGrabbable grabbable1 = other.gameObject.GetComponent<OVRGrabbable>();
        OVRGrabbable grabbable2 = other.gameObject.GetComponent<OVRGrabbable>();
        if (grabbable1 != null && grabbable1.isGrabbed && grabbable2 != null && grabbable2.isGrabbed)
        {
           

        }
        audioSource.clip = correctMatch;
        audioSource.Play();
    }


}