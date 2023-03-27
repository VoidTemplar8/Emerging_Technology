using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDeactivate : MonoBehaviour
{
    //public string matchSoundtag;
    public GameObject objectSound;
    private bool isObjectActive = true;
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.CompareTag(matchSoundtag)) 
        //{

            AudioSource audioSource = GetComponent<AudioSource>();
            OVRGrabbable grabbable1 = collision.gameObject.GetComponent<OVRGrabbable>();
            OVRGrabbable grabbable2 = collision.gameObject.GetComponent<OVRGrabbable>();
            if (grabbable1 != null && grabbable1.isGrabbed)
            {
                objectSound.GetComponent<AudioSource>().Stop();
                objectSound.SetActive(false);
                isObjectActive = false;
            }
            if (grabbable2 != null && grabbable2.isGrabbed)
            {
            objectSound.GetComponent<AudioSource>().Stop();
            objectSound.SetActive(false);
                isObjectActive = false;
            //GameObject.Find("matchsound").GetComponent<AudioSource>().Stop();
            }
        //}
       
    }
}
