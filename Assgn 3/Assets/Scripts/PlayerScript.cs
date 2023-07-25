// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: PlayerScript.cs
// Author: Yvonne Lim & Stella Tan

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

    public static int totalDmgTaken;

    public GameController gameController;
    public ShootingScript shoot;

    private void Start()
    {
        //Game.SetPlayer(new Player(CharacterSelect.currCharacter));
        Game.SetPlayer(new Player(CharacterSelect.currCharacter));
        UpdatePlayer();

        //DataManager dataManager = GetComponent<DataManager>();

        shoot = this.transform.GetChild(0).GetComponent<ShootingScript>();

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

            UpdateWeapon();
        }

        
    }

    private void UpdateWeapon(){
        string speedData = Game.GetPlayer().GetActiveWeapon().GetData("speed");
        Debug.Log("speedData: "+ speedData);
        float speedFloat = 0.0f;
        // Try to parse
        if (float.TryParse(speedData, out speedFloat))
        {
            // Conversion successful, timeBetwFiring now contains the integer value
            Debug.Log("timeBetwFiring: " + speedFloat);

            // For eg 
            // (10-8)/10 = 0.2f where 8 is weapon speed
            // (10-2)/10 = 0.8f where 2 is weapon speed
            // 0.2 will shoot faster than 0.8
            shoot.timeBetwFiring = (10.0f - speedFloat)/10;
        }
        else
        {
            // Conversion failed, handle the error here
            Debug.LogError("Error: Failed to convert speedData to a float.");
            shoot.timeBetwFiring = 0; // Set to 0 to disallow shooting.
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
        
        if(currHealth - dmgTaken < 0)
            currHealth = 0;
        else
            currHealth -= dmgTaken;

        //Debug.Log(currHealth);
        //UpdatePlayer();

        totalDmgTaken += dmgTaken;

        if (currHealth <= 0)
        {
            Debug.Log("you ded");
            gameController.EndGame(false);
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
