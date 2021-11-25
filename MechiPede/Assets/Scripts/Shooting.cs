using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;       //bullet Prefab
    [SerializeField]
    public Transform FirePoint;     //Players Firepoint
    public bool CanShoot = false;   //Lol Bool to shoot
    public float FireRate = 0.5f;   //lol FireRate to limit shooting
    public float NextShot = 0.1f;    //lol time to wait before you actually can shoot

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))  //to let player shoot
        { 
            Shoot();
        }
    }

    //Code-logic to shoot
    void Shoot()
    {
        if(Time.time > NextShot)
        {
            CanShoot = true;
        }

        if(CanShoot == true)
        {
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            NextShot = Time.time + FireRate;
            CanShoot = false;
        }
    }
}
