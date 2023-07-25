using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private ItemSpawnController spawnController;
    public IngredientData data;
    public Transform parent;
    public Vector3 offset;
    public float followSpeed = 2.0f;
    public float reachDistance = 0.1f;

    public static int ingredientsShot;

    private PlayerScript _player;
    // Start is called before the first frame update
    void Start()
    {
        spawnController = GameObject.FindObjectOfType<ItemSpawnController>();
        _player = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(parent == null){
        //     if(spawnController.pickedUp[0] == this.gameObject){
        //         parent = _player.transform;
        //     }
        // }
        Follow(parent);
    }
    
    // Follow parent if not null
    void Follow(Transform parentTransform){
        if(parent != null){
            if (parent.tag == "Bowl"){
                followSpeed = 5.0f;
                offset = Vector3.zero;
                if(ReachedParent()){
                    // Hide game objects from user POV
                    parent.GetComponent<Bowl>().AddToBowl(this.gameObject);
                    this.gameObject.SetActive(false);
                    AdjustPlayerStats();
                    ++ingredientsShot;
                    spawnController.pickedUp[0] = null; // Set to null so Player can pick up items again
                }
            }
            else if (parent.tag == "Player"){
                followSpeed = 10.0f;
            }
            this.transform.position = Vector2.Lerp(this.transform.position, parentTransform.position + offset, followSpeed * Time.deltaTime);
        }
    }

    public void AdjustPlayerStats()
    {
        Debug.Log(data.buffType);
        Debug.Log(data.ingredientName);
        if(data.buffType == "HP")
        {
            _player.AddHealth(int.Parse(data.buffValue));
        }
        if(data.buffType == "ATTK")
        {
            _player.AddDamage(int.Parse(data.buffValue));
        }
        if(data.buffType == "SPD")
        {
            _player.AddSpeed(int.Parse(data.buffValue));
        }
    }

    private bool ReachedParent()
    {
        if (parent == null)
            return false;

        float distance = Vector3.Distance(transform.position, parent.position);
        return distance <= reachDistance;
    }
   
    // // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    // void OnTriggerStay2D(Collider2D col)
    // {
    //     // If press spacebar and parent==null
    //     // parent == null cause otherwise, it will run this code multiple times
    //     // Take note: this is OnTriggerStay2D, it will run this code as long as player is in contact
    //     if(Input.GetKey(KeyCode.Space) && parent == null){
    //         parent = col.gameObject.transform;
    //         spawnController.pickedUp.Add(this.gameObject);
    //         spawnController.Trigger();
    //     }   
            
        
    // }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            if(spawnController.pickedUp[0] == null){
                parent = _player.transform;
                spawnController.pickedUp.Add(this.gameObject);
                spawnController.Trigger();
            }           
        }
    }
}
