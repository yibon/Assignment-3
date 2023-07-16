// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: GameController.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public string initCharacter;

    public PlayerScript player;
    public EnemyScript enemy;

    public float followeingSpeed;

    float horizontalIP;
    float verticalIP;
    Vector2 direction;

    private void Start()
    {
        DataManager dataManager = GetComponent<DataManager>();
        dataManager.LoadRefCharacterData();
        dataManager.LoadRefEnemyData();

        Game.SetPlayer(new Player(CharacterSelect.currCharacter));
        //Debug.Log(Game.GetPlayer().GetCurrentCharacter());
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            DialogueManager.currCutscene = "602";
            SceneLoader.LoadScene(SceneLoader.Scenes.Cutscene1);
        }

        direction = new Vector2(horizontalIP, verticalIP).normalized;
    }

    private void FixedUpdate()
    {
        player.MovePlayer(direction * Time.fixedDeltaTime);

        // following speed should be taken from data
        if (EnemyScript.enemycurrHP> 0)
        {
            enemy.FollowPlayer(player.GetPosition(), 1f, followeingSpeed * Time.fixedDeltaTime);
        }
    }

}
