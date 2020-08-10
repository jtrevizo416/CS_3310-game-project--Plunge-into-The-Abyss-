using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource ammo, enemyDeath, enemyShot, gunShot, health, playerHurt, pistolShot, shotgunShot, smgShot, cacoShoot, cacoDeath, cacoNearby,cacoPain, itemPickup;//references to various sound effects

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

    public void PlayItemPickup()
    {
        itemPickup.Stop();
        itemPickup.Play();
    }

    public void PlayCacoPain()
    {
        cacoPain.Stop();
        cacoPain.Play();
    }

    public void PlayCacoDeath()
    {
        cacoDeath.Stop();
        cacoDeath.Play();
    }

    public void PlayCacoShoot()
    {
        cacoShoot.Stop();
        cacoShoot.Play();
    }

    public void PlayCacoNearby()
    {
        cacoNearby.Stop();
        cacoNearby.Play();
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
