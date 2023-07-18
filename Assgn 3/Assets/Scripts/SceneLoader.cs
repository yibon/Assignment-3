// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: SceneLoader.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public enum Scenes
    {
        MainMenu,
        Cutscene1,
        CharacterSelect,
        MainScene,
        WeaponSelect
    }

    public static void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
