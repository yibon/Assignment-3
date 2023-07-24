// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: Player.cs
// Author: Yvonne Lim

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string currrentCharacter;

    private string playerName, playerWeapon;
    private int playerHP;
    private int playerAtt;
    private int playerSpeed;
    private int playerMainAttSpeed;
    private int playerRamenAttSpeed;

    private bool isDirty;

    public static Weapon RamenWeapon;
    public static Weapon MainWeapon;

    public static event Action<string> WeaponChanged;
    public Player (string currrentCharacter)
    {
        this.currrentCharacter = currrentCharacter;

        isDirty = true;
    }

    public string GetCurrentCharacter()
    {
        return currrentCharacter;
    }

    public void SetCurrentCharacter (string _avatar)
    {
        currrentCharacter = _avatar;

        isDirty = true;
    }

    public bool UpdatePlayerStats()
    {
        if (!isDirty)
            return false;

        Character playerCharacter = Game.GetCharacterByRefId(currrentCharacter);

        playerName = playerCharacter.characterName;
        playerHP = playerCharacter.characterHP;
        playerAtt = playerCharacter.characterAttk;
        playerSpeed = playerCharacter.characterMoveSpeed;

        isDirty = false;
        return true;
    }
    public void SetPlayerWeapon(string weaponName){
        playerWeapon = weaponName;
        WeaponChanged?.Invoke(weaponName);

    }
    public string GetPlayerWeapon(){
        return playerWeapon;
    }
    public Weapon GetActiveWeapon(){
        Debug.Log("Current weapon is "+ playerWeapon);
        if(playerWeapon == "Ramen")
            return RamenWeapon;
        
        return MainWeapon;
    }
    public string GetPlayerName()
    {
        UpdatePlayerStats();
        return playerName;
    }

    public int GetPlayerHP()
    {
        UpdatePlayerStats();
        return playerHP;
    }

    public int GetPlayerAtt()
    {
        UpdatePlayerStats();
        return playerAtt;
    }

    public int GetPlayerSpeed()
    {
        UpdatePlayerStats();
        return playerSpeed;
    }
}
