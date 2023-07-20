using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public IngredientList ingredientList;
    // Start is called before the first frame update
    void Start()
    {
        string json_ingredient =   "Assets/Data/JSON/ingredients.json";
        
        if (File.Exists(json_ingredient))
        {
            string jsonData = File.ReadAllText(json_ingredient);

            // Deserialize the JSON data into C# objects
            ingredientList = JsonUtility.FromJson<IngredientList>(jsonData);

            // // Access the ingredient data
            // foreach (IngredientData ingredientData in ingredientList.ingredient)
            // {
            //     Debug.LogWarning("Ingredient ID: " + ingredientData.ingredientId);
            //     Debug.LogWarning("Ingredient Name: " + ingredientData.ingredientName);
            //     Debug.LogWarning("Buff Description: " + ingredientData.buffDescription);
            //     Debug.LogWarning("Buff Type: " + ingredientData.buffType);
            //     Debug.LogWarning("Buff Value: " + ingredientData.buffValue);
            // }
        }
        else
        {
            Debug.LogError("JSON file not found: " + json_ingredient);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
