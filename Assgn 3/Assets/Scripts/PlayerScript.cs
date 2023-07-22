// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: PlayerScript.cs
// Author: Yvonne Lim

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [HideInInspector]public Player Player;

    public static int currHealth;
    public static int currAttack;
    public static int currSpeed;

    private void Start()
    {
        //Game.SetPlayer(new Player(CharacterSelect.currCharacter));
        Game.SetPlayer(new Player(CharacterSelect.currCharacter));
        UpdatePlayer();
        Player.SetPlayerWeapon("Enemy");

    }
    private void Update()
    {
        ToggleWeapon();
    }
    public void ToggleWeapon(){
        
        if(Input.GetKeyUp(KeyCode.Space)){
            // Debug.LogWarning("Player weapon is " + Player.GetPlayerWeapon());
            if(Player.GetPlayerWeapon() == "Enemy"){
                Player.SetPlayerWeapon("Ramen");
            }else if(Player.GetPlayerWeapon() == "Ramen"){
                Player.SetPlayerWeapon("Enemy");
            }
        }
    }
    public void MovePlayer (Vector2 direction)
    {
        //move player position
        this.transform.position += (Vector3)direction * Game.GetPlayer().GetPlayerSpeed();
    }

    public Vector2 GetPosition()
    {
        return this.transform.position;
    }

    public void TakeDamage(int dmgTaken)
    {
        currHealth -= dmgTaken;
        Debug.Log(currHealth);
        //UpdatePlayer();

        if (currHealth <= 0)
        {
            Debug.Log("you ded");
        }
    }
    public void AddHealth(int healthToAdd)
    {
        currHealth += healthToAdd;
        Debug.Log(currHealth + " Hello im here");
    }
    public void AddDamage(int damageToAdd)
    {
        currAttack += damageToAdd;
        Debug.Log(currAttack + " Hello im here");
    }
    public void AddSpeed(int speedToAdd)
    {
        currSpeed += speedToAdd;
        Debug.Log(currSpeed + " Hello im here");
    }

    public void UpdatePlayer()
    {
        Player = Game.GetPlayer();

        currHealth = Player.GetPlayerHP();
        currAttack = Player.GetPlayerAtt();
        currSpeed = Player.GetPlayerSpeed();
    }
}
