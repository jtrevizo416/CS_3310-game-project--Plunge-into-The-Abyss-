using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolWeaponController : MonoBehaviour
{
    public int gunDamage;
    public int currentAmmo;
    public GameObject bulletImpact;
    public Camera viewCam;
    public PlayerController Player;
    //public EnemyController Enemy;
    private bool hasDied;
    public Animator gunAnim;
    public Text ammoText;
    private EnemyController enemy;
    public static PistolWeaponController instance;
    private bool isReady;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        ammoText.text = currentAmmo.ToString();//Ammo Text
        enemy = GameObject.Find("Enemy").GetComponent<EnemyController>();
    }

    // Update is called once per frame
    private void Update()
    {
        //WeaponDamage();
        DeathCheck();
        if (hasDied == false)
        {
            if (Input.GetMouseButtonDown(0) && isReady)
            { 
                Shoot(); 
            }
           
        }

    }

    private void IsReady()//set weapon as ready to fire when animation is done or hasnt started
    {
        isReady = true;
    }

    private void IsNotReady()//set weapon as not ready during fire animation
    {
        isReady = false;
    }

    private void Shoot()
    {

        //shooting mechanics
        //GetMouseButton For Full Auto, GetMouseButtonDown for Semi Auto
        if (currentAmmo > 0)
        {
            Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));//create raycast for shooting
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))// if something is hit enter loop
            {

                //Debug.Log("I'm looking at " + hit.transform.name);
                Instantiate(bulletImpact, hit.point, transform.rotation);

                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.parent.GetComponent<EnemyController>().TakeDamage(gunDamage);
                }
            }
            else
            {

                //Debug.Log("I'm looking at nothing");
            }
            currentAmmo--;
            AudioController.instance.PlayPistolShot();//play gunshot sound when player shoots
            gunAnim.SetTrigger("Fire");
            updateAmmoUI();
        }
    }

    private void DeathCheck()
    {
        if (Player.currentHealth <= 0)
        {
            hasDied = true;
        }
    }

    public void updateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString();//Ammo Text
    }

    //public void WeaponDamage()
    //{
    //    gunDamage = baseDamage * damageMultiplier;
    //}

    public void setAmmo(int amount)
    {
        currentAmmo += amount;
    }
}
