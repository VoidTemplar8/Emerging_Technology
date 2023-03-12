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

    public TextMeshProUGUI countText;
    private int count;

    private void Start()
    {
        count = 0;
        UpdateCountText();
    }

    public void AddToCount()
    {
        count++;
        UpdateCountText();
        CheckWinCondition();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //    foreach (string tag in targetTags)
        //    {
        //        if (collision.gameObject.CompareTag(tag))
        //        {
        //            OVRGrabbable grabbable1 = collision.gameObject.GetComponent<OVRGrabbable>();
        //            OVRGrabbable grabbable2 = collision.collider.gameObject.GetComponent<OVRGrabbable>();

        //            if (grabbable1 != null && grabbable1.grabbedBy != null && grabbable1.isGrabbed && grabbable2 != null && grabbable2.grabbedBy != null && grabbable2.isGrabbed)
        //            {
        //                if (collision.collider.gameObject.CompareTag(tag))
        //                {
        //                    Destroy(collision.gameObject);
        //                    Destroy(collision.collider.gameObject);

        //                    AddToCount();

        //                    AudioSource audioSource = GetComponent<AudioSource>();
        //                    audioSource.clip = correctMatch;
        //                    audioSource.Play();
        //                }
        //            }

        //            break; // exit the loop if a tag match is found
        //        }
        //    }

        foreach (string tag in targetTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                OVRGrabbable grabbable1 = collision.gameObject.GetComponent<OVRGrabbable>();
                OVRGrabbable grabbable2 = null;

                foreach (ContactPoint contact in collision.contacts)
                {
                    if (contact.thisCollider.gameObject.GetComponent<OVRGrabbable>() != null && contact.thisCollider.gameObject.GetComponent<OVRGrabbable>().grabbedBy != null && contact.thisCollider.gameObject.GetComponent<OVRGrabbable>().isGrabbed)
                    {
                        grabbable1 = contact.thisCollider.gameObject.GetComponent<OVRGrabbable>();
                        break;
                    }
                    else if (contact.otherCollider.gameObject.GetComponent<OVRGrabbable>() != null && contact.otherCollider.gameObject.GetComponent<OVRGrabbable>().grabbedBy != null && contact.otherCollider.gameObject.GetComponent<OVRGrabbable>().isGrabbed)
                    {
                        grabbable2 = contact.otherCollider.gameObject.GetComponent<OVRGrabbable>();
                        break;
                    }
                }

                if (grabbable1 != null && grabbable1.grabbedBy != null && grabbable1.isGrabbed && grabbable2 != null && grabbable2.grabbedBy != null && grabbable2.isGrabbed)
                {
                    Destroy(collision.gameObject);
                    Destroy(collision.contacts[0].otherCollider.gameObject);

                    AddToCount();

                    AudioSource audioSource = GetComponent<AudioSource>();
                    audioSource.clip = correctMatch;
                    audioSource.Play();
                }
                Destroy(collision.gameObject);
                break; // exit the loop if a tag match is found
            }
        }
    }

    private void CheckWinCondition()
    {
        if (count == 1)
        {
            SceneManager.LoadScene("WinGame");
        }
    }

    private void UpdateCountText()
    {
        countText.text = "Count: " + count;
    }
}