using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
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
}
