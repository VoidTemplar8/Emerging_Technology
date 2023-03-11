using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindfold : MonoBehaviour
{
    //public Canvas blindFolder;
    public GameObject blindFolder;
    private bool isObjectActive = false;
  

    void Start()
    {
       // blindFolder.gameObject.SetActive(false);
        blindFolder.SetActive(false);
       
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (!isObjectActive)
            {
                blindFolder.SetActive(true);
                isObjectActive = true;
              
            }
            else
            {
                blindFolder.SetActive(false);
                isObjectActive = false;
            
            }
        }
    }
}
