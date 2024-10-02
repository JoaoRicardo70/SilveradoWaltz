using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scrArmashud : MonoBehaviour
{
    public static scrArmashud instance;
    public Image weaponSpriteUI;
    public Slider ammoSlider;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateWeaponHUD(scrArma weapon)
    {
        weaponSpriteUI.sprite = weapon.weaponSprite;
        ammoSlider.maxValue = weapon.CheiaMunicao;
        ammoSlider.value = weapon.municao;
    }

    public void UpdateAmmoHUD(int currentAmmo)
    {
        ammoSlider.value = currentAmmo;
    }
}
