// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: WeaponViewController.cs
// Author: Stella Tan

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponViewController : MonoBehaviour
{

    [Header("BG Sprites")]
    [SerializeField] private Sprite _selectedSprite;
    [SerializeField] private Sprite _unselectedSprite;

    [Header("Ramen UI")]
    [SerializeField] private Image Ramen_bg;
    [SerializeField] private Image Ramen_image;
    [SerializeField] private TMP_Text Ramen_attackDamage;
    [SerializeField] private TMP_Text Ramen_attackSpeed;

    [Header("Main Weapon UI")]
    [SerializeField] private Image MainWeapon_bg;
    [SerializeField] private Image MainWeapon_image;
    [SerializeField] private TMP_Text MainWeapon_attackDamage;
    [SerializeField] private TMP_Text MainWeapon_attackSpeed;

    private void Start()
    {
        Player.WeaponChanged += OnWeaponChange;
        Ramen_bg.sprite = _unselectedSprite;
        MainWeapon_bg.sprite = _selectedSprite;
        InitaliseWeaponUI();
    }
    private void OnDestroy()
    {
        Player.WeaponChanged -= OnWeaponChange;
    }

    private void InitaliseWeaponUI()
    {
        var ramenWeapon = Player.RamenWeapon;
        var mainWeapon = Player.MainWeapon;

        //Ramen ui
        Ramen_image.sprite = ramenWeapon.sprite;
        Ramen_attackDamage.text = "Attack: " + ramenWeapon.attack;
        Ramen_attackSpeed.text = "Speed: " + ramenWeapon.speed;

        MainWeapon_image.sprite = mainWeapon.sprite;
        MainWeapon_attackDamage.text = "Attack: " + mainWeapon.attack;
        MainWeapon_attackSpeed.text = "Speed: " + mainWeapon.speed;
    }

    private void OnWeaponChange(string weaponName)
    {
        if(weaponName == "Ramen")
        {
            Ramen_bg.sprite = _selectedSprite;
            MainWeapon_bg.sprite = _unselectedSprite;
        }
        if(weaponName == "Enemy")
        {
            Ramen_bg.sprite = _unselectedSprite;
            MainWeapon_bg.sprite = _selectedSprite;
        }
        InitaliseWeaponUI();
    }
}
