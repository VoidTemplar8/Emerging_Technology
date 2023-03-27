using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get { return instance; } }

    //public TextMeshProUGUI countText;
    private int count;
    private static GameManager _instance;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(GameManager.instance);
    }

    void Start()
    {
       count= 0;
    }

    public void ObjectDestroyer(GameObject gameObject)
    {
        
        Destroy(gameObject);

    }


    public void AddToCount()
    {
        count++;
        UpdateCountText();
        CheckWinCondition();
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
       // countText.text = "Count: " + count;
    }


}
