using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string[] targetTags; // the tags of the game objects we want to destroy upon collision
    public AudioClip correctMatchSound;
    public TextMeshProUGUI matchedObjectCountText;
    private int matchedObjectCount;

    void Start()
    {
        // Initialize the matched object count to zero
        matchedObjectCount = 0;
        UpdateMatchedObjectCountText();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has one of the target tags
        if (ArrayContainsString(targetTags, other.tag))
        {
            // Check if the collided object is being held by a controller
            OVRGrabbable grabbable = other.gameObject.GetComponent<OVRGrabbable>();
            if (grabbable != null && grabbable.isGrabbed)
            {
                // If the collided object is being held by a controller, destroy it
                Destroy(other.gameObject);
                PlayCorrectMatchSound();

                // Increment the matched object count and update the UI text
                matchedObjectCount++;
                UpdateMatchedObjectCountText();
            }
        }
    }

    private bool ArrayContainsString(string[] array, string str)
    {
        foreach (string s in array)
        {
            if (s == str)
            {
                return true;
            }
        }
        return false;
    }

    private void PlayCorrectMatchSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = correctMatchSound;
        audioSource.Play();
    }

    private void UpdateMatchedObjectCountText()
    {
        matchedObjectCountText.text = "Matched Objects: " + matchedObjectCount.ToString();
    }
}
