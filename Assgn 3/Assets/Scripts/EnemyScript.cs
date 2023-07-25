// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: EnemyScript.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemycurrHP;
    public float enemycurrAttack;
    public float enemycurrSpeed;

    public static int enemiesDefeated;

    public string currEnemyId;

    public PlayerScript player;
    private Mob _mob;

    private void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<PlayerScript>();

        Game.SetMob(new Mob(currEnemyId));
        UpdateMob();
    }

    //public void OnDataLoadEnemy()
    //{
    //}

    private void FixedUpdate()
    {
        if (enemycurrHP > 0)
        {
            FollowPlayer(player.GetPosition(), 1f, enemycurrSpeed * Time.fixedDeltaTime);
        }
    }

    public void FollowPlayer(Vector2 playerPos, float minDist, float followingSpeed)
    {
        if (Vector2.Distance(transform.position, playerPos) > minDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, followingSpeed * 0.3f);
        }
    }

    private void TakeDamage()
    {
        string attackData = Game.GetPlayer().GetActiveWeapon().GetData("attack");
        
        float attackFloat = 0.0f;

        // Try to parse
        if (float.TryParse(attackData, out attackFloat))
        {
            // Conversion successful, timeBetwFiring now contains the integer value
            enemycurrHP -= attackFloat;
            Debug.Log("Enemy(" + this.gameObject + ") HP: " + enemycurrHP);
            if (enemycurrHP <= 0)
            {
                ++enemiesDefeated;
                Destroy(gameObject);
            }
        }
        else
        {
            // Conversion failed, handle the error here
            Debug.LogError("Error: Failed to convert attackData to a float.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check the weapon type here
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log(enemycurrHP);
            TakeDamage();
            Debug.Log("Enemy Hit");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            // Player will take damage according to enemy's current attack
            
            player.TakeDamage(Mathf.RoundToInt(enemycurrAttack));
        }
    }

    public void UpdateMob()
    {
        _mob = Game.GetMob();

        enemycurrHP = _mob.GetMobHP();
        enemycurrAttack = _mob.GetMobAtt();
        enemycurrSpeed = _mob.GetMobSpeed();
    }

    //public void SetCurrentEnemy(string enemyId)
    //{
    //    currEnemyId = enemyId;
    //}
}
