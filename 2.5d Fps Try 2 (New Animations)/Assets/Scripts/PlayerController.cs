using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D theRB;// player rigid body reference

    public float moveSpeed;//movement speed of the player

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f; //speed mouse rotates camera

    public Camera viewCam; //Reference to the player camera

   // public GameObject bulletImpact;//reference for bullet impact
   // public int currentAmmo;//ammo ammount

   // public Animator gunAnim;//reference to the gun animation
    public Animator anim;//reference to headbob animation

    public int currentHealth;//player current health
    public int maxHealth = 100;//player max health
    public GameObject deadScreen;//game over screen
    private bool hasDied;

    public Text healthText; //ammoText;//values to display on hud for amount of ammon and health

    public bool headbob;//enable or disable headbob

    

    private void Awake()
    {
        instance = this;
    }

    void Start()// Start is called before the first frame update
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString() + "%";//health text

        //ammoText.text = currentAmmo.ToString();//Ammo Text

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasDied)//if player is not dead allow movement
        {
            //player movement
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));//get input for movement

            Vector3 moveHorizontal = transform.up * -moveInput.x;//Get the up value and multiply it with whatever value we have for horizontal movement

            Vector3 moveVertical = transform.right * moveInput.y;//Get the right/left value and multiply it with whater value we have for the vertical movement

            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

            //player camera controll
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

            //shooting mechanics
            //GetMouseButton For Full Auto, GetMouseButtonDown for Semi Auto
            //if (Input.GetMouseButtonDown(0))
            //{
            //    if (currentAmmo > 0)
            //    {
            //        Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));//create raycast for shooting
            //        RaycastHit hit;
            //        if (Physics.Raycast(ray, out hit))// if something is hit enter loop
            //        {
                        
            //            //Debug.Log("I'm looking at " + hit.transform.name);
            //            Instantiate(bulletImpact, hit.point, transform.rotation);

            //            if (hit.transform.tag == "Enemy")
            //            {
            //                hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
            //            }

            //        }
            //        else
            //        {

            //            //Debug.Log("I'm looking at nothing");
            //        }
            //        currentAmmo--;
            //        AudioController.instance.PlayGunshot();//play gunshot sound when player shoots
            //        gunAnim.SetTrigger("Fire");
            //        updateAmmoUI();
            //    }
            //}

           

            if (headbob)//if enabled
            {
                if (moveInput != Vector2.zero)//if player is moving headbob
                {
                    anim.SetBool("IsMoving", true);
                }
                else
                {
                    anim.SetBool("IsMoving", false);
                }
            }
            else if (!headbob)//if disabled
            {
                anim.SetBool("IsMoving", false);
            }
        }
    }

    public void TakeDamage(int damageAmount)//player function for taking damage
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)//if player dies show game over screen
        {
            deadScreen.SetActive(true);
            hasDied = true;
            currentHealth = 0;
        }

        healthText.text = currentHealth.ToString() + "%";//health text

        AudioController.instance.PlayPlayerHurt();//When player takes damage play player hurt sound effect
    }

    public void AddHealth(int healAmount)//player function for healing
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = currentHealth.ToString() + "%";
    }

    //public void updateAmmoUI()
    //{
    //    ammoText.text = currentAmmo.ToString();//Ammo Text
    //}
}
