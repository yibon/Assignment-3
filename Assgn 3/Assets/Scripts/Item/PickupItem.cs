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
        followSpeed = 2.0f;
        spawnController = GameObject.FindObjectOfType<ItemSpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow(parent);

        if(parent != null){
            if(parent.gameObject.tag == "Bowl"){
                Debug.Log("Sent to a bowl");
            }
        }
    }
    
    // Follow parent if not null
    public void Follow(Transform parentTransform){
        
        if(parent != null){
            if(parent.tag != "Player"){
                offset = Vector3.zero;
                if(reachedTarget()){
                    parent.GetComponent<Bowl>().AddToBowl(this.gameObject);
                    this.gameObject.SetActive(false);
                }
            }
            this.transform.position = Vector2.Lerp(this.transform.position,parentTransform.position + offset, followSpeed * Time.deltaTime);
            
            
        }
    }
    private bool reachedTarget(){
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
        Debug.Log("COlliding with: "+ col.gameObject.name);
        if(parent != null && this.gameObject.activeSelf == true){
            if(parent.gameObject.tag == "Bowl"){
                Debug.Log("DEBUG1");
                
                // parent.GetComponent<Bowl>().AddToBowl(this.gameObject);
                
                // foreach (Transform child in parent){
                //     if(child.name == this.name){
                //         parent.GetComponent<Bowl>().AddToBowl(this.name);
                //     }
                // }                    
            }
        }
        
    }
}
