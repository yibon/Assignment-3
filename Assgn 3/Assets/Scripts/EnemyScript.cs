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

    private void Start()
    {
        // Replace this with data
        enemycurrHP = 100;
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
}
