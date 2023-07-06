using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string currrentCharacter;

    private string playerName;
    private int playerHP;
    private int playerAtt;
    private int playerSpeed;

    private bool isDirty;

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
