using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Player _player;

    public int currHealth;
    public int currAttack;
    public int currSpeed;

    private void Start()
    {
        Game.SetPlayer(new Player(CharacterSelect.currCharacter));

        UpdatePlayer();
    }

    private void Update()
    {
        //UpdatePlayer();

    }

    public void MovePlayer (Vector2 direction)
    {
        //move player position
        this.transform.position += (Vector3)direction * Game.GetPlayer().GetPlayerSpeed();
    }

    public Vector2 GetPosition()
    {
        return this.transform.position;
    }

    public void TakeDamage(int dmgTaken)
    {
        currHealth -= dmgTaken;
        Debug.Log(currHealth);
        UpdatePlayer();

        if (currHealth < 0)
        {
            Debug.Log("you ded");
        }
    }

    public void UpdatePlayer()
    {
        _player = Game.GetPlayer();

        currHealth = _player.GetPlayerHP();
        currAttack = _player.GetPlayerAtt();
        currSpeed = _player.GetPlayerSpeed();
    }
}
