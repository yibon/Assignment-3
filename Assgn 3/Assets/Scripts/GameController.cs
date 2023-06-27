using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerScript player;

    float horizontalIP;
    float verticalIP;
    Vector2 direction;

    private void FixedUpdate()
    {
        horizontalIP = Input.GetAxisRaw("Horizontal");
        verticalIP = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontalIP, verticalIP).normalized;

        player.MovePlayer(direction * Time.fixedDeltaTime);
    }
}
