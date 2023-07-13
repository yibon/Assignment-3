// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: Game.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    private static Player player;

    private static List<Dialogue> dialogueList;
    private static List<Character> characterList;
    
    public static Player GetPlayer()
    {
        return player;
    }

    public static void SetPlayer(Player _player)
    {
        player = _player;
    }

    public static List<Dialogue> GetDialogueList()
    {
        return dialogueList;
    }

    public static void SetDialogueList(List<Dialogue> _list)
    {
        dialogueList = _list;
    }

    public static Dialogue GetDialogueByRefId(string _refId)
    {
        return dialogueList.Find(x => x.cutsceneRefId == _refId);
    }

    public static List<Character> GetCharacterList()
    {
        return characterList;
    }

    public static void SetCharacterList(List<Character> _list)
    {
        characterList = _list;
    }

    public static Character GetCharacterByRefId(string _refId)
    {
        return characterList.Find(x => x.characterId == _refId);
    }

}
