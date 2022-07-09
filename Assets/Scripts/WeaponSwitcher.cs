using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private int currentWeapon = 0;
    
    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();
        
        if (previousWeapon != currentWeapon) SetWeaponActive();
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentWeapon = 2;
    }
    
    private void ProcessScrollWheel()
    {
        if (0 < Input.GetAxis("Mouse ScrollWheel"))
        {
            if (transform.childCount - 1 <= currentWeapon) currentWeapon = 0;
            else currentWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon <= 0) currentWeapon = transform.childCount - 1;
            else currentWeapon--;
        }
    }


    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)  weapon.gameObject.SetActive(true);
            else  weapon.gameObject.SetActive(false);
            weaponIndex++;
        }
    }

}
