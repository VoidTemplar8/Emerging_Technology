using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour
{
    public AudioClip audioClip;
    public string[] tagsToDetect;

    void OnCollisionEnter(Collision collision)
    {
        if (ArrayContains(tagsToDetect, collision.gameObject.tag))
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    bool ArrayContains(string[] array, string value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return true;
            }
        }
        return false;
    }
}
