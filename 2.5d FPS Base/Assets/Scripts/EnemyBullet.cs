using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount;//damage

    public float bulletSpeed = 5f;//bullet speed

    public Rigidbody2D theRB;//reference to rigidbody

    private Vector3 direction;//variable to determine player direction

    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;//determine player position
        direction.Normalize();
        direction = direction * bulletSpeed;//calculate the direction of the bullet
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")//detect if the bullet hits the player
        {
            PlayerController.instance.TakeDamage(damageAmount);//call the take damage function

            Destroy(gameObject);//destroy the bullet
        }
        else if (other.tag == "Wall")//detect if the bullet is hitting the wall
        {
            Destroy(gameObject);
        }
    }
}
