using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGameManager : MonoBehaviour
{
    public string[] tagsToMatch;
    public int matchesNeeded = 3;
    private int currentMatches = 0;
    private List<GameObject> matchedObjects = new List<GameObject>();

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is already matched
        if (matchedObjects.Contains(collision.gameObject))
        {
            return;
        }

        // Check if the colliding object matches with any other object
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tagsToMatch[0]))
        {
            if (obj == collision.gameObject || matchedObjects.Contains(obj))
            {
                continue;
            }

            if (collision.gameObject.CompareTag(obj.tag))
            {
                // Increase the current matches count
                currentMatches++;

                // Add the matched objects to the list
                matchedObjects.Add(collision.gameObject);
                matchedObjects.Add(obj);

                // Destroy the matched objects
                Destroy(collision.gameObject);
                Destroy(obj);

                // Check if enough matches have been made
                if (currentMatches >= matchesNeeded)
                {
                    // Do something when enough matches have been made
                    Debug.Log("Matches made!");
                    currentMatches = 0; // Reset the matches count
                    matchedObjects.Clear(); // Clear the list of matched objects
                }

                break;
            }
        }
    }
}
