// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: EnemyScript.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyScript : MonoBehaviour
{
    public static float enemycurrHP;
    public static float enemycurrAttack;
    public static float enemycurrSpeed;

    private Mob _mob;

    private void Start()
    {
        // Replace this with data
        Game.SetMob(new Mob("3001"));

        UpdateMob();
    }

    private void Update()
    {
        //Debug.Log("Enemy HP: " + enemycurrHP);
        //Debug.Log("Enemy Attack: " + enemycurrAttack);
        //Debug.Log("Enemy Speed: " + enemycurrSpeed);
    }

    public void FollowPlayer(Vector2 playerPos, float minDist, float followingSpeed)
    {
        if (Vector2.Distance(transform.position, playerPos) > minDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, followingSpeed);
        }
    }
    
    private void TakeDamage()
    {
        enemycurrHP -= PlayerScript.currAttack;
        if (enemycurrHP < 0)
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
    }
    public void UpdateMob()
    {
        _mob = Game.GetMob();

        enemycurrHP = _mob.GetMobHP();
        enemycurrAttack = _mob.GetMobAtt();
        enemycurrSpeed = _mob.GetMobSpeed();
    }
}
