// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: Recipe.cs
// Author: Stella Tan

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