using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Weapons;

public class WeaponAmmoUI : MonoBehaviour
{

    [SerializeField] TMP_Text ammo_txt;
    [SerializeField] TMP_Text weaponName_txt;
    WeaponComponent WeaponComponent;

    private void OnEnable()
    {
        PlayerEvents.OnWeaponEquipped += OnWeaponEquipped;
    }

    private void OnWeaponEquipped(WeaponComponent weaponComponent)
    {
        WeaponComponent = weaponComponent; 
    }

    private void OnDisable()
    {
        PlayerEvents.OnWeaponEquipped -= OnWeaponEquipped;
    }

    private void Update()
    {
        if (!WeaponComponent) return;
        weaponName_txt.text = WeaponComponent.WeaponInformation.WeaponName;
        ammo_txt.text = WeaponComponent.WeaponInformation.BulletsInClip.ToString() + "/" + WeaponComponent.WeaponInformation.BulletsAvailable.ToString();
    }
}
