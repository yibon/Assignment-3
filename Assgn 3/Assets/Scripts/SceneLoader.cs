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
        MainScene
    }

    public static void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
