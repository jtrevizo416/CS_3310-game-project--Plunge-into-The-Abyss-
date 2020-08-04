using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int weaponIndex = 0;//index of the weapon based on the hiearchy on the weapon holder

    // Start is called before the first frame update
    void Start()
    {
        weaponSelection();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = weaponIndex;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)//check if player scrolled the mouse wheel
        {
            if (weaponIndex <= 0)
            {
                weaponIndex = 0;
            }
            else
            {
                weaponIndex++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)//check if player scrolled the mouse wheel
        {
            if (weaponIndex <= 0)
            {
                weaponIndex = transform.childCount - 1;
            }
            else
            {
                weaponIndex--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))//select first weapon with "1" key
        {
            weaponIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)//select second weapon with "2" key
        {
            weaponIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)//select third weapon with "3" key
        {
            weaponIndex = 2;
        }



        if (previousWeapon != weaponIndex)
        {
            weaponSelection();
        }

    }

    void weaponSelection()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponIndex)//check the weapon index value, and activate the weapon for that index
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
