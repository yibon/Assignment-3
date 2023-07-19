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

    public ItemSpawnController pickedItem;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canFire = true;
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
        if(numCollidersUnderMouse>0){
            if (Input.GetMouseButton(0) && canFire)
            {
                for (int i = 0; i < numCollidersUnderMouse; ++i)
                {
                    // Check if collidersUnderMouse[i] is the type of object you want using tags or GetComponent()
                    // Then do what you want to it
                    GameObject collidedObj = collidersUnderMouse[i].gameObject;
                    if(collidedObj.tag =="Bowl"){
                        Debug.Log(pickedItem.pickedUp[0]);
                        pickedItem.pickedUp[0].GetComponent<PickupItem>().parent = collidedObj.transform;
                        // if(collidedObj.name == "Original Ramen"){
                        //     collidedObj.GetComponent<Bowl>().
                        // }
                    }
                }
            }
        }
        else{
            if (Input.GetMouseButton(0) && canFire)
            {
                canFire = false;
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            }
        }

    }
}
