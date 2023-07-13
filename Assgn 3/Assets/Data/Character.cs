// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: Character.cs
// Author: Yvonne Lim


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character
{
    public string characterId { get; }
    public string characterName { get; }

    public int characterHP { get; }
    public int characterAttk { get; }
    public int characterMoveSpeed { get; }

    public Character (string characterId, string characterName, int characterHP, 
                      int characterAttk, int characterMoveSpeed)
    {
        this.characterId = characterId;
        this.characterName = characterName;
        this.characterHP = characterHP;
        this.characterAttk = characterAttk;
        this.characterMoveSpeed = characterMoveSpeed;
    }
}
