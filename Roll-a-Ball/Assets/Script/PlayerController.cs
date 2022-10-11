using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI lifeText;
    public GameObject winTextObject; // do not need change text so we use gameobject ref
    public GameObject GAmeOverObject;
    public GameObject playButton;
    public GameObject time;

    public GameOverScreen gameOverScreen;
    public YouWinScreen youWinScreen;
    


    [SerializeField] private AudioSource rollSoundEffect;
    [SerializeField] private AudioSource bgSoundEffect;
    [SerializeField] private AudioSource crashSoundEffect;
    [SerializeField] private AudioSource pointCollectSoundEffect;



    private Rigidbody rb;
    private int point;
    private int life=3;
    private float movementX;
    private float movementY;
    private object material;

    // Start is called before the first frame update
     void Start()
    {
        rb = GetComponent<Rigidbody>(); //get rigid body attach to the player
        point = 0;
        SetPointText();
        lifeText.text = "LifeLines: " + life.ToString();
        winTextObject.SetActive(false);
        GAmeOverObject.SetActive(false);
        playButton.SetActive(false);
        bgSoundEffect.Play();
    }
    void OnMove(InputValue movementValue)
    {
       
        Vector2 movementVector = movementValue.Get<Vector2>();//get vec 2 data from movementValue and stre vec 2 variable 

        movementX = movementVector.x;
        movementY = movementVector.y;

        if ((movementX != 0) || (movementY != 0))

        {

            rollSoundEffect.Play();

        }
        else
        {
            rollSoundEffect.Stop();
        }


    }

    void SetPointText()
    {
        pointText.text = "Points: " + point.ToString();

        if(point>=150)
        {
            youWinScreen.Setup(point);
            winTextObject.SetActive(true);
            FindObjectOfType<GameManager>().Pause();
            time.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    

    void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void Update()
    {
        lifecount();
    }
    
    private void lifecount()
    {
        lifeText.text = "lifes: " + life.ToString();
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
            pointCollectSoundEffect.Play();
            other.gameObject.SetActive(false);
            point = point + 10;

            SetPointText();
            
        }
        else if(other.gameObject.CompareTag("CubeBlue") && (GetComponent<Renderer>().material.color == Color.blue))
        {
            pointCollectSoundEffect.Play();
            other.gameObject.SetActive(false);
            point = point + 10;

            SetPointText();
           

        }
        else if (other.gameObject.CompareTag("CubeRed") && (GetComponent<Renderer>().material.color == Color.red))
        {
            pointCollectSoundEffect.Play();
            other.gameObject.SetActive(false);
            point = point + 10;

            SetPointText();
           

        }
        else
        {
            crashSoundEffect.Play();
            life--;
            lifecount();
            if (life <= 0)
            {
                bgSoundEffect.Stop();
                FindObjectOfType<GameManager>().GameOver();

                gameOverScreen.Setup(point);

                //ball need deactivate
                gameObject.SetActive(false);
                time.SetActive(false);
            }
           

        }





    }

    






}
