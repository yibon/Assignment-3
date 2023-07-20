using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private ItemSpawnController spawnController;
    public Transform parent;
    public Vector3 offset;
    public float followSpeed = 2.0f;
    public float reachDistance = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        spawnController = GameObject.FindObjectOfType<ItemSpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow(parent);
    }
    
    // Follow parent if not null
    void Follow(Transform parentTransform){
        if(parent != null){
            if (parent.tag == "Bowl"){
                followSpeed = 5.0f;
                offset = Vector3.zero;
                if(ReachedParent()){
                    parent.GetComponent<Bowl>().AddToBowl(this.gameObject);
                    this.gameObject.SetActive(false);
                }
            }
            else if (parent.tag == "Player"){
                followSpeed = 10.0f;
            }
            this.transform.position = Vector2.Lerp(this.transform.position, parentTransform.position + offset, followSpeed * Time.deltaTime);
        }
    }

    private bool ReachedParent()
    {
        if (parent == null)
            return false;

        float distance = Vector3.Distance(transform.position, parent.position);
        return distance <= reachDistance;
    }
   
    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerStay2D(Collider2D col)
    {
        // If press spacebar and parent==null
        // parent == null cause otherwise, it will run this code multiple times
        // Take note: this is OnTriggerStay2D, it will run this code as long as player is in contact
        if(Input.GetKey(KeyCode.Space) && parent == null){
            parent = col.gameObject.transform;
            spawnController.pickedUp.Add(this.gameObject);
            spawnController.Trigger();
        }   
            
        
    }
}
