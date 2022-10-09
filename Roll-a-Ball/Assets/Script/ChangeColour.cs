using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public Material nMaterial;

    void Start()
    {
        InvokeRepeating("setClourToBlack",0f,5f);
    }

    public void setClourToBlack()
    {
        nMaterial.SetColor("_Color",Color.black);
    }
}
