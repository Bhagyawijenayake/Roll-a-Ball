using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YouWinScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int points)
    {
        gameObject.SetActive(true);
        pointsText.text = "You earn " +points.ToString() + " POINTS";
    }
}
