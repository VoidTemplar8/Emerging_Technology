using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // the name of the scene to change to

    private OVRInput.Controller controller = OVRInput.Controller.LTouch;

    private OVRInput.Controller controller2 = OVRInput.Controller.RTouch;

    void Update()
    {
        // check if the left controller trigger is pressed
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            // load the new scene
            SceneManager.LoadScene(sceneName);
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller2))
        {
            // load the new scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
