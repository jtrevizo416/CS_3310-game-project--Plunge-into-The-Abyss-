using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmoPickup : MonoBehaviour
{
    public int ammoAmount = 25;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ShotgunWeaponController.instance.currentAmmo += ammoAmount;
            ShotgunWeaponController.instance.updateAmmoUI();

            AudioController.instance.PlayAmmoPickup();//play sound for ammo pickup

            Destroy(gameObject);
        }

    }
}
