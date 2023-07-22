using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{

    public HashSet<GameObject> myIngredients = new HashSet<GameObject>();
    public HashSet<GameObject> receivedIngredient = new HashSet<GameObject>();
    public bool recipeComplete = false;
    public BowlController controller;
    [SerializeField] private GameObject ingredientImagePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        // // Read from json instead
        // foreach(Transform child in this.transform){
        //     myIngredients.Add(child.gameObject);
        // }

        GetNextStatue();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsBowlFull() && !recipeComplete){
            
            recipeComplete = true;
            GetNextStatue();
        }
        else{

        }
    }
    private void GetNextStatue(){
        Recipe recipe = controller.NextStatue(this);
        if(recipe != null){

            float startingX = this.transform.position.x - 1.5f;
            
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
        else{
            // Game ended
        }
    }
    public bool IsBowlFull(){
        
        // Check if the two sets have the same elements
        if (receivedIngredient.SetEquals(myIngredients))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   
    public void AddToBowl(GameObject ingredient){
        
        foreach(GameObject child in myIngredients){
            if(child.name == ingredient.name)    {
                receivedIngredient.Add(child);
                child.SetActive(false);
                break;
            }
        }
    }

}
