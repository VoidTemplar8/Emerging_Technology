using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
    public GameObject[] objectsToMatch;
    public int matchesNeeded = 3;
    private int currentMatches = 0;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is one of the objects to match
        foreach (GameObject obj in objectsToMatch)
        {
            if (collision.gameObject == obj)
            {
                // Increase the current matches count
                currentMatches++;

                // Destroy the matched object
                Destroy(obj);

                // Check if enough matches have been made
                if (currentMatches >= matchesNeeded)
                {
                    // Do something when enough matches have been made
                    Debug.Log("Matches made!");
                    currentMatches = 0; // Reset the matches count
                }

                break;
            }
        }
    }
}
