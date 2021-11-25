using UnityEngine;

public class bullet : MonoBehaviour
{
    public float velo = 10f;    //speed of travel

    public Rigidbody2D rig2d;   //rigidbody on bullet

    

    // Start is called before the first frame update
    void Start()
    {
        rig2d.velocity = transform.up * velo;  //shoots bullet
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.CompareTag("Player"))
        Destroy(gameObject);
    }
    
}
