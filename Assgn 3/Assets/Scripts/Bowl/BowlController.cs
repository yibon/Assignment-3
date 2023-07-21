using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class BowlController : MonoBehaviour
{
    public RecipeList recipeList;
    public List<Recipe> statues = new List<Recipe>();

    public List<Bowl> bowls = new List<Bowl>();
    public int statueCounter = 0;
    
    // [SerializeField] private List<Sprite> allIngredients = new List<Sprite>();
    public ItemSpawnController spawnController;
    public bool GameCompleted = false;
    // Start is called before the first frame update
    void Awake()
    {
        
        // Read json
        string json_statues = "Assets/Data/JSON/statues.json";
        
        if (File.Exists(json_statues))
        {
            string jsonData = File.ReadAllText(json_statues);

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
        if (statueCounter <= statues.Count){
            return statues[statueCounter++];
        }
        else{
            GameCompleted = true;
            return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}