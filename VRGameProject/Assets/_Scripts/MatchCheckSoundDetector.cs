using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCheckSoundDetector : MonoBehaviour
{
    public AudioClip readyMatch;
    private void OnTriggerEnter(Collider other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        OVRGrabbable grabbable1 = other.gameObject.GetComponent<OVRGrabbable>();
        OVRGrabbable grabbable2 = other.gameObject.GetComponent<OVRGrabbable>();
        if (grabbable1 != null && grabbable1.isGrabbed && grabbable2 != null && grabbable2.isGrabbed)
        {
            if (other.gameObject.CompareTag("Cube"))
            {
                audioSource.clip = readyMatch;
                audioSource.Play();
            }

        }
    }
}
