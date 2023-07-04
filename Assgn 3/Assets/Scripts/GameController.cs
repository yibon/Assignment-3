using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerScript player;
    public EnemyScript enemy;

    float horizontalIP;
    float verticalIP;
    Vector2 direction;

    private void Update()
    {
        horizontalIP = Input.GetAxisRaw("Horizontal");
        verticalIP = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontalIP, verticalIP).normalized;
    }

    private void FixedUpdate()
    {
        player.MovePlayer(direction * Time.fixedDeltaTime);


        enemy.FollowPlayer(player.GetPosition(), 1f, 3f * Time.fixedDeltaTime);
    }
}
