using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource ammo, enemyDeath, enemyShot, gunShot, health, playerHurt, pistolShot, shotgunShot, smgShot;//references to various sound effects

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPistolShot()//play gunshot sound for pistol
    {
        pistolShot.Stop();
        pistolShot.Play();
    }

    public void PlayShotgunShot()//play gunshot sound for shotgun
    {
        shotgunShot.Stop();
        shotgunShot.Play();
    }

    public void PlaySmgShot()//play gunshot sound for smg
    {
        smgShot.Stop();
        smgShot.Play();
    }

    public void PlayAmmoPickup()//Play sound for when player pickups ammo
    {
        ammo.Stop();
        ammo.Play();
    }

    public void PlayEnemyDeath()//Play sound for when enemy dies
    {
        enemyDeath.Stop();
        enemyDeath.Play();
    }

    public void PlayEnemyShot()//Play sound for when enemy takes damage
    {
        enemyShot.Stop();
        enemyShot.Play();
    }

    public void PlayGunshot()//Play sound for when player shoots
    {
        gunShot.Stop();
        gunShot.Play();
    }

    public void PlayHealthPickup()//Play sound for when player pickups a health pack
    {
        health.Stop();
        health.Play();
    }

    public void PlayPlayerHurt()//Play sound for when player takes damage
    {
        playerHurt.Stop();
        playerHurt.Play();
    }

   
}
