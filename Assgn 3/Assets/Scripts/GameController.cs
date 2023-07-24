// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: GameController.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    //public string initCharacter;

    public PlayerScript player;
    public EnemyScript enemy;
    public EWaveManager eWave;

    DataManager dataManager;


    //public float followeingSpeed;

    float horizontalIP;
    float verticalIP;
    Vector2 direction;

    // Game Complete
    public GameObject gameEndPanel;

    private void Start()
    {
        //DataManager dataManager = GetComponent<DataManager>();
        //dataManager.LoadRefCharacterData(player.OnDataLoadPlayer);
        //dataManager.LoadRefEnemyData(enemy.OnDataLoadEnemy);
        //dataManager.LoadRefEWaveData(eWave.OnDataLoadEWave);

        dataManager = GetComponent<DataManager>();
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        horizontalIP = Input.GetAxisRaw("Horizontal");
        verticalIP = Input.GetAxisRaw("Vertical");

        //player.UpdatePlayer();
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            //Debug.Log("Alohaaa");
            player.TakeDamage(10);
        }
        
        // win condition
        if (Input.GetKeyDown(KeyCode.P))
        {
            dataManager.SaveData();
            DialogueManager.currCutscene = "602";
            SceneLoader.LoadScene(SceneLoader.Scenes.Cutscene1);
        }

        direction = new Vector2(horizontalIP, verticalIP).normalized;

    }

    private void FixedUpdate()
    {
        player.MovePlayer(direction * Time.fixedDeltaTime);
    }

    public void EndGame(bool gameStatus){
        // Game completed
        if(gameStatus){
            gameEndPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Congratulation!";
        }
        // Game failed
        else{
            gameEndPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Try Again...";
        }

        gameEndPanel.SetActive(true);
        Debug.Log(Time.timeScale);
        Time.timeScale = 0.0f;
    }

    public void GoToMainMenu(){
        SceneLoader.LoadScene(SceneLoader.Scenes.MainMenu);
    }
    public void RestartGame(){
        SceneLoader.LoadScene(SceneLoader.Scenes.CharacterSelect);
    }
}
