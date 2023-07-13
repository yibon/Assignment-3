// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: MainMenu.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static void StartGame()
    {
        DialogueManager.currCutscene = "601";
        SceneLoader.LoadScene(SceneLoader.Scenes.Cutscene1);
    }

    public static void HowToPlay()
    {
        Debug.Log("How To Play");
    }

    public static void QuitGame()
    {
        Debug.Log("Game Ends!");
    }

}
