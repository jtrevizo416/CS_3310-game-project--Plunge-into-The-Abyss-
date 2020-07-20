using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 3;//enemy health
    public GameObject Explosion;//reference to explosion prefab

    public float playerRange = 10f;//range that the player has to be to enter attack mode

    public Rigidbody2D theRB;//rigidbody reference

    public float moveSpeed;//move speed of enemy

    public bool shouldShoot;
    public float fireRate = .5f;
    private float shotCounter;
    public GameObject Bullet;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange) //compare the position of the enemy and the player and see if enemy is close enough
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;//find which direction the player is facing

            theRB.velocity = playerDirection.normalized * moveSpeed;//set velocity with the maximum of 1 for the player direction value to stop enemy from moving too fast

            if (shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    Instantiate(Bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                }
            }
        }
        else 
        {
            theRB.velocity = Vector2.zero;
        }
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);//if health is 0 or below destroy the enemy object
            Instantiate(Explosion, transform.position, transform.rotation);//once enemy is killed instantiate explosion animation and face the player

            AudioController.instance.PlayEnemyDeath();//play death sound when enemy dies
        }
        else 
        {
            AudioController.instance.PlayEnemyShot();//play shot sound when enemy takes damage
        }
    }
}
