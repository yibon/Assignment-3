// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: EnemyScript.cs
// Author: Yvonne Lim

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    public void FollowPlayer(Vector2 playerPos, float minDist, float followingSpeed)
    {
        if (Vector2.Distance(transform.position, playerPos) > minDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, followingSpeed);
        }
    }
}
