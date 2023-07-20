// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: PlayerScript.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Player _player;

    public static int currHealth;
    public static int currAttack;
    public static int currSpeed;

    private void Start()
    {
        // Delete this line if you want the character to be chosen from the select screen
        // CharacterSelect.currCharacter = "1";
        
        Game.SetPlayer(new Player(CharacterSelect.currCharacter));
        UpdatePlayer();
        _player.SetPlayerWeapon("Enemy");

    }
    private void Update()
    {
        ToggleWeapon();
    }
    public void ToggleWeapon(){
        
        if(Input.GetKeyUp(KeyCode.Space)){
            Debug.LogWarning("Player weapon is " + _player.GetPlayerWeapon());
            if(_player.GetPlayerWeapon() == "Enemy"){
                _player.SetPlayerWeapon("Ramen");
            }else if(_player.GetPlayerWeapon() == "Ramen"){
                _player.SetPlayerWeapon("Enemy");
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

    public void UpdatePlayer()
    {
        _player = Game.GetPlayer();

        currHealth = _player.GetPlayerHP();
        currAttack = _player.GetPlayerAtt();
        currSpeed = _player.GetPlayerSpeed();
    }
}
