using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI pointText;
    public GameObject winTextObject; // do not need change text so we use gameobject ref


    private Rigidbody rb;
    private int point;
    private float movementX;
    private float movementY;
    private object material;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //get rigid body attach to the player
        point = 0;
        SetPointText();
        winTextObject.SetActive(false);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();//get vec 2 data from movementValue and stre vec 2 variable 

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetPointText()
    {
        pointText.text = "Points: " + point.ToString();

        if(point>=50)
        {
            winTextObject.SetActive(true);
        }
    }


    private void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY); 
        
        rb.AddForce(movement*speed);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube") && (GetComponent<Renderer>().material.color ==Color.yellow))
        {
            other.gameObject.SetActive(false);
            point = point + 10;

            SetPointText();
        }
        else if(other.gameObject.CompareTag("CubeBlue") && (GetComponent<Renderer>().material.color == Color.blue))
        {
            other.gameObject.SetActive(false);
            point = point + 10;

            SetPointText();

        }
        else if (other.gameObject.CompareTag("CubeRed") && (GetComponent<Renderer>().material.color == Color.red))
        {
            other.gameObject.SetActive(false);
            point = point + 10;

            SetPointText();

        }



    }


}
