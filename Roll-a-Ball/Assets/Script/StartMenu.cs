using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    void Awake()
    {
        
    }

    void Start()
    {
       
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
        //test code 
        Debug.Log("Play Game");
    }
}
