// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: BowlController.cs
// Author: Stella Tan


using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*
 * This class holds the statues by reading statues.json file
 * And allow Bowl.cs to retrieve the next statue
*/
public class BowlController : MonoBehaviour
{
    public RecipeList recipeList;
    [SerializeField] public TextAsset jsonTextAsset;

    public List<Recipe> statues = new List<Recipe>();

    public List<Bowl> bowls = new List<Bowl>();
    public int statueCounter = 0;

    // [SerializeField] private List<Sprite> allIngredients = new List<Sprite>();
    public ItemSpawnController spawnController;
    public bool GameCompleted = false;
    public GameController gameController;

    // Start is called before the first frame update
    void Awake()
    {
                
        if (jsonTextAsset != null)
        {
            // Read json
            string jsonData = jsonTextAsset.text;

            // Deserialize the JSON data into C# objects
            recipeList = JsonUtility.FromJson<RecipeList>(jsonData);

            // Access the ingredient data
            foreach (Recipe recipeData in recipeList.statues)
            {
                // Debug.LogWarning("Statue ID: " + recipeData.statueId);
                // Debug.LogWarning("Statue Name: " + recipeData.statueName);
                recipeData.SetIngredientLists(recipeData.ingredientId);
                statues.Add(recipeData);
            }
        }
        else
        {
            Debug.LogError("JSON file not found: " + recipeList);
        }
       
    }
    public Sprite GetSprite(string name){
        foreach(Sprite sprite in spawnController.allIngredients){
            if(name == sprite.name)
                return sprite;
        }
        return null;
    }
    public Recipe NextStatue(Bowl bowl){
        // If bowl completed, they will automatically request for NextStatue, but if statusCounter is already > statues.Count, it will go to GameCompleted
   

        if (statueCounter <= statues.Count){
            return statues[statueCounter++];
        }
        else{
            GameCompleted = true;
            gameController.EndGame(GameCompleted);
            return null;
        }
    }
}
