using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerMoves : MonoBehaviour
{
    protected GameController gameG;  //Gamecontroller

    [SerializeField]
    private Vector2 startPosition = new Vector2(0, -400);  //start position

    [SerializeField]
    private float pSpeed = 5.0f;   //Player Speed

    private Rigidbody2D rb;     //Rigidbody physics component
    private float horizontalMovement = 0f;  //Movement on X-Axis
    private float verticalMovement = 0f;    //Movement on Y-Axis
    private Vector2 moves;                  //Creates movement in combination with Axis.
    public int score = 0;                   //Score of the player
    public int pLive = 3;                  //Player lives
    public Text lifeTxt;            //Shows remaining lives in UI
    public Text scoreTxt;           //Shows points in UI
    private Scene scene;


    // Start is called before the first frame update
    void Start()
    {
        gameG = GameObject.Find("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;   //respawn
        scoreTxt = GameObject.Find("scoreTxt").GetComponent<Text>();
        lifeTxt = GameObject.Find("lifeTxt").GetComponent<Text>();
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Centipede"))
        {
            pLive--;  //minus for the Players lives

            if(pLive <= 0)
            {
                GameOverPlayer();
                Destroy(gameObject);
            }
            else
            {
                GoToStartPosition();
            }
        }
        lifeTxt.text = pLive.ToString();
    }

    //respawn at startposition
    public void GoToStartPosition()
    {
        rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        transform.position = startPosition;
    }


    //Shows score, and makes a W possible
    void FixedUpdate()
    {

        horizontalMovement = Input.GetAxis("Horizontal") * pSpeed;
        verticalMovement = Input.GetAxis("Vertical") * pSpeed;

        moves = new Vector2(horizontalMovement, verticalMovement);
        rb.velocity = moves * pSpeed;

        ShowScore();
        GameObject[] MechiPede = GameObject.FindGameObjectsWithTag("Centipede");

        if(MechiPede.Length <= 0 && scene.name == "Level15")
        {
            GameWinLoad();
        }
    }

    //GameOver for the Player
    public void GameOverPlayer()
    {

        if (pLive <= 0)
        {
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            SceneManager.LoadScene("GameLost");
        }
    }

    //score is defined
    public void ShowScore()
    {
        GameObject[] MechiPede = GameObject.FindGameObjectsWithTag("Centipede");
        GameObject[] tShroom = GameObject.FindGameObjectsWithTag("Mushroom");

        if(gameObject.CompareTag("Centipede"))
        {
            score += 50;
        }
        else if(gameObject.CompareTag("Mushroom"))
        {
            score += 15;
        }

        scoreTxt.text = score.ToString();
    }

    public void GameWinLoad()
    {
         SceneManager.LoadScene("GameWin");
    }
}
