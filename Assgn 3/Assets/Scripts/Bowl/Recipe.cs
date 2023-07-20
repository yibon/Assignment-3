using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Recipe
{
            // "ingredientId": "6001@6002@6003"
    public string statueId;
    public string statueName;
    public string ingredientId;
    public string[] ingredientList;

    public void SetIngredientLists(string ingredientId){
        this.ingredientList = ingredientId.Split('@');
    }
}