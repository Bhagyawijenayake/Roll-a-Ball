using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    private float time = 0;
    private int currentColorArray = 0;
    public Color[] colorArray = new Color[3];
    public Renderer renderer;

    private void Start()
    {
        renderer.material.SetColor("_Color", Color.yellow);
    }

    void Update()
    {
        colorArray[0] = Color.blue;
        colorArray[1] = Color.red;
        colorArray[2] = Color.yellow;

        if (colorArray.Length > 0)
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                if (colorArray.Length <= currentColorArray) currentColorArray = 0;
                renderer.material.SetColor("_Color", colorArray[currentColorArray]);
                time = 0;
                currentColorArray++;
            }

         }
    }
}
