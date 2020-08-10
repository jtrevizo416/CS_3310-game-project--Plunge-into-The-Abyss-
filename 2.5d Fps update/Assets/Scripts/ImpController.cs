using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ImpController : MonoBehaviour
{
    public int health = 3;//enemy health
    public GameObject ImpDeath;//reference to death animation
    public GameObject ImpExplosion;//reference to explosion animation
    public GameObject ImpForwardFacing;//reference to Imp Forward Facing animation
    public GameObject ImpLeftFacing;//reference to Imp Left Facing animation
    public GameObject ImpRightFacing;//reference to Imp Right Facing animation
    public GameObject ImpBackFacing;//reference to Imp Back Facing animation
    public float playerRange = 10f;//range that the player has to be to enter attack mode

    public Rigidbody2D theRB;//rigidbody reference

    public float moveSpeed;//move speed of enemy

    public bool shouldShoot;
    public float fireRate = .5f;
    private float shotCounter;
    public GameObject Bullet;
    public Transform firePoint;
    public bool DeathFromGun;
    public bool DeathFromExplosion;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {

        
        

        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange) //compare the position of the enemy and the player and see if enemy is close enough
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;//find which direction the player is facing

            theRB.velocity = playerDirection.normalized * moveSpeed;//set velocity with the maximum of 1 for the player direction value to stop enemy from moving too fast

            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
            theRB.rotation = angle;

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

        //partial code for rotation

        if (theRB.rotation == (Mathf.Atan2(0, 1) * Mathf.Rad2Deg))//if enemy is facing away from player
        {

        }
        if (theRB.rotation == (Mathf.Atan2(0, -1) * Mathf.Rad2Deg))//if enemy is facing towards player
        {

        }
        if (theRB.rotation == (Mathf.Atan2(-1, 0) * Mathf.Rad2Deg))//if enemy is facing left
        { 
        
        }
        if (theRB.rotation == (Mathf.Atan2(1, 0) * Mathf.Rad2Deg))//if enemy is facing right
        { 
        
        }
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0 && DeathFromGun)
        {
            Destroy(gameObject);//if health is 0 or below destroy the enemy object
            Instantiate(ImpDeath, transform.position, transform.rotation);//once enemy is killed instantiate explosion animation and face the player

            AudioController.instance.PlayEnemyDeath();//play death sound when enemy dies
        }
        else if (health <= 0 && DeathFromExplosion)
        {
            Destroy(gameObject);//if health is 0 or below destroy the enemy object
            Instantiate(ImpExplosion, transform.position, transform.rotation);//once enemy is killed instantiate explosion animation and face the player

            AudioController.instance.PlayEnemyDeath();//play death sound when enemy dies
        }
        else
        {
            AudioController.instance.PlayEnemyShot();//play shot sound when enemy takes damage
        }
    }
}
