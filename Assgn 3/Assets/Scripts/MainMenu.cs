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
        SceneLoader.LoadScene(SceneLoader.Scenes.LoadingScreen);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

}
