using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PedeMoves : MonoBehaviour
{
    public bool isCollide;                              // Boolean determining whether the centipede hits something
    public bool isDown;                                 // Boolean determining the direction (Top -> Bottom OR Bottom -> Top)
    public bool isRight;                                // Boolean determining the direction (Left -> Right OR Right -> Left)
    public int order;                                   // Order of the centipede
    public int scoreCentipede = 50;                     // Score of each centipede when the player shot
    public float centipedeSpeed = 1000f;                // Speed that the centipede can travel in cells per second
    public Vector3 direction;                           // Current direction of the centipede

    private float nextMove = 0;                         // Time the centipede can move to the next cell
    private Rigidbody2D rb;                             // Rigidbody of the centipede object
    private GridGeneration gridInfo;                    // Grid and scene generation information
    private PlayerMoves playerInfo;                    // Player information
    public GameController gamerCon;                     //gameController is here for giving Speed
    public bool pedeHead;                               //to determin the pedes head
    public float pedeLeg;                               //to determin the pedes leg placement
    public Animator anim;                               //to animate sprites
    public SpriteRenderer sprite;                       //to render sprites

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial properties
        isCollide = false;
        isDown = true;
        isRight = true;
        direction = Vector3.right;
        // Get the components
        rb = GetComponent<Rigidbody2D>();
        gridInfo = GameObject.Find("Background").GetComponent<GridGeneration>();
        playerInfo = GameObject.Find("Player").GetComponent<PlayerMoves>();
        gamerCon = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Determine the direction of the centipede before moving
        CheckMovable(direction);
        CentipedeMove();
        PedeSpeed();
    }

    public void PedeSpeed()
    {
        GetSetSpeed();
    }

    //Set the speed value
    public void GetSetSpeed()
    {
        centipedeSpeed = gamerCon.masterSpeed;
    }


    
    void CentipedeMove()
    {
        // Move from left to right
        if (isRight)
        {
            direction = Vector3.right;
        }
        // Move from right to left
        else
        {
            direction = Vector3.left;
        }

        // Collide with something
        if (isCollide)
        {
            // Move from top to bottom
            if (isDown)
            {
                direction = Vector3.down;
            }
            // Move from bottom to top
            else
            {
                direction = Vector3.up;
            }
        }

        // Move the centipede by the speed (units / s)
        if (Time.time > nextMove)
        {
            isCollide = false;
            nextMove = Time.time + 1f / centipedeSpeed;
            rb.MovePosition(transform.position + direction);
            // After moving to the next row, immediately change to continue moving in the same row
            // Move from left to right
            if (isRight)
            {
                direction = Vector3.right;
            }
            // Move from right to left
            else
            {
                direction = Vector3.left;
            }
        }
    }

    // Check if the centipede can move to the selected direction
    void CheckMovable(Vector3 direction)
    {
        GameObject[] MechiPede = GameObject.FindGameObjectsWithTag("Centipede");
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, 1);
        foreach (RaycastHit2D h in hits)
        {
                // Change the horizontal direction between left and right
                if (h.collider.gameObject.CompareTag("Wall") || h.collider.gameObject.CompareTag("Mushroom"))
                {
                    isCollide = true;
                    isRight = isRight == true ? false : true;
                }
                // Change the vertical direction between up and down
                else if (h.collider.gameObject.CompareTag("Top") || h.collider.gameObject.CompareTag("Down"))
                {
                    isCollide = true;
                    isDown = isDown == true ? false : true;
                }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Hit by a bullet will destroy this piece of centipede
        if (col.gameObject.CompareTag("Bullet"))
        {
            GameObject[] MechiPede = GameObject.FindGameObjectsWithTag("Centipede");
            for (int i = 0; i < MechiPede.Length; i++)
            {
                // The rest of the centipede will move in the opposite direction
                if (i < order)
                {
                    MechiPede[i].GetComponent<PedeMoves>().isRight = isRight == true ? false : true;
                }
            }
            Destroy(gameObject);
            playerInfo.score += scoreCentipede;
        }
    }
}
