// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: ShootingScript.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    public GameObject bullet;
    public Transform bulletTransform;

    public bool canFire;
    private float timer;
    public float timeBetwFiring;
    public ItemSpawnController ingredients;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canFire = true;
        ingredients = GameObject.FindObjectOfType<ItemSpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotateZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotateZ);
        
        if(!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetwFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        Collider2D[] collidersUnderMouse = new Collider2D[4];
        int numCollidersUnderMouse = Physics2D.OverlapPoint(mousePos, new ContactFilter2D(), collidersUnderMouse);
        
        if (Input.GetMouseButton(0) && canFire)
        {
            if(numCollidersUnderMouse>0){
                for (int i = 0; i < numCollidersUnderMouse; ++i)
                {
                    // Check if collidersUnderMouse[i] is the type of object you want using tags or GetComponent()
                    // Then do what you want to it
                    GameObject obj = collidersUnderMouse[i].gameObject;
                    
                    if(Game.GetPlayer().GetPlayerWeapon() == "Ramen"){
                        if(obj.tag == "Bowl"){
                            // Set pickup parent's so it will follow it
                            ingredients.pickedUp[0].GetComponent<PickupItem>().parent = obj.transform;

                            // Add picked up ingredient into bowl
                            obj.GetComponent<Bowl>().AddToBowl(ingredients.pickedUp[0]);
                        }
                    }
                }
            }
            else{
                if(Game.GetPlayer().GetPlayerWeapon() == "Enemy"){
                    canFire = false;
                    Instantiate(bullet, bulletTransform.position, Quaternion.identity);
                }
            }
        }


    }
}
