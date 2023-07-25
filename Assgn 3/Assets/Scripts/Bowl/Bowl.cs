// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: Bowl.cs
// Author: Stella Tan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{

    [SerializeField]
    public HashSet<GameObject> myIngredients = new HashSet<GameObject>();
    public HashSet<GameObject> receivedIngredient = new HashSet<GameObject>();
    public List<GameObject> list_myingredients = new List<GameObject>();

    public BowlController controller;
    [SerializeField] private GameObject ingredientImagePrefab;
    public static int statuesCompeleted = 0;

    // Start is called before the first frame update
    void Start()
    {
        // // Read from json instead
        // foreach(Transform child in this.transform){
        //     myIngredients.Add(child.gameObject);
        // }

        GetNextStatue();
        
    }

    void updatelist(){
        list_myingredients.Clear();

        List<GameObject> tempList = new List<GameObject>(myIngredients);
        list_myingredients.AddRange(tempList);
    }
    // Update is called once per frame
    void Update()
    {
        // if(IsBowlFull()){
            
        //     GetNextStatue();
            
        // }
        // else{

        // }
    }
    private void GetNextStatue(){
        

        Recipe recipe = controller.NextStatue(this);
        if(recipe != null){


            // Control the offset of where to spawn the ingredients needed at each bowl
            // The higher the offset, the further backwards the ingredients will spawn from
            float offset = 1.5f;
            if(recipe.ingredientList.Length == 4)
                offset = 2.0f;
            else if(recipe.ingredientList.Length == 5)
                offset = 4.0f;
            else if(recipe.ingredientList.Length == 6)
                offset = 6.0f;

            float startingX = this.transform.position.x - offset;
            
            for(int i=0; i<recipe.ingredientList.Length; i++){
                string currentIngredient = recipe.ingredientList[i];
                
                GameObject tempIngredient = Instantiate(ingredientImagePrefab, this.transform.position, transform.rotation);
                
                tempIngredient.transform.parent = this.transform;
                tempIngredient.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                tempIngredient.transform.position = new Vector3(startingX + i*1.5f, this.transform.position.y + 1f, 1.0f);
                
                // Set the sprite
                Sprite currentSprite = controller.GetSprite(currentIngredient);
                if(currentSprite != null)
                    tempIngredient.GetComponent<SpriteRenderer>().sprite = currentSprite;

                tempIngredient.name = currentIngredient;
                myIngredients.Add(tempIngredient);
            }


        }

        updatelist();
    }
    public bool IsBowlFull(){
        
        // Check if the two sets have the same elements
        if (receivedIngredient.SetEquals(myIngredients))
        {
            ++statuesCompeleted;
            return true;
        }
        else
        {
            return false;
        }
    }
   
    public void AddToBowl(GameObject ingredient){
        
        // Add to bowl
        foreach(GameObject child in myIngredients){
            if(child.name == ingredient.name)    {
                receivedIngredient.Add(child);
                child.SetActive(false);
                
            }
        }

        // If bowl is full, get next recipe
        if(IsBowlFull()){
            // Move on to new statue, removed all my ingredients and received ingredients
            ResetBowl();

            GetNextStatue();
            
        }
    }

    private void ResetBowl(){
        
        myIngredients.Clear();
        receivedIngredient.Clear();

        // foreach(Transform child in this.transform){
        //     Destroy(child.gameObject);
        // }

        

    }

}
