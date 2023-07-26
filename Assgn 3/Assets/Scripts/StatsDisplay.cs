// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: StatsDisplay.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    private Player _player;
    //public PlayerScript playerScript;

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text hpText;
    //[SerializeField] private TMP_Text attText;
    [SerializeField] private TMP_Text speedText;

    [SerializeField] private TMP_Text enemiesDefeatedText;
    [SerializeField] private TMP_Text ingredientsShotText;
    [SerializeField] private TMP_Text statuesCompletedText;
    [SerializeField] private TMP_Text dmgTakenText;


    private void Start()
    {
        _player = Game.GetPlayer();
    }

    private void Update()
    {
        nameText.text = "Character: " + _player.GetPlayerName();
        hpText.text = "HP: " + PlayerScript.currHealth;
        //attText.text = "Attack: " + PlayerScript.currAttack;
        speedText.text = "Speed: " + PlayerScript.currSpeed;

        enemiesDefeatedText.text = "Enemies Defeated: " + EnemyScript.enemiesDefeated;
        ingredientsShotText.text = "Ingredients Successfully Collected: " + PickupItem.ingredientsShot;
        statuesCompletedText.text = "Ramen Bowls Completed: " + Bowl.statuesCompeleted;
        dmgTakenText.text = "Total Damage Taken: " + PlayerScript.totalDmgTaken;
    }
}
