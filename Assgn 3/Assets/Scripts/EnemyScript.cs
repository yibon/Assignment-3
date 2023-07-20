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
        //             vv Change this to the Weapon 
        enemycurrHP -= PlayerScript.currAttack;
        if (enemycurrHP <= 0)
        {
            Destroy(gameObject);
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
