using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI  pointsText;

    public void Setup(int points)
    {
        gameObject.SetActive(true);
        pointsText.text = points.ToString()+ " POINTS";
    }

}
