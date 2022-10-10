using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject winTextObject;
    public GameObject time;

    private int point;
    private int life;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI lifeText;

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }


    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;

    }
}
