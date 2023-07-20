using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public HashSet<GameObject> myIngredients = new HashSet<GameObject>();
    public HashSet<GameObject> receivedIngredient = new HashSet<GameObject>();
    public bool recipeComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in this.transform){
            myIngredients.Add(child.gameObject);
        }
        
        // myIngredients = SortReceivedIngredients(myIngredients);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(IsBowlFull()){
            Debug.Log("This recipe is done.");
            recipeComplete = true;
        }
        else{

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
        // receivedIngredient = SortReceivedIngredients(receivedIngredient);
    }

    // private HashSet<GameObject> SortIngredients(HashSet<GameObject> arr)
    // {
    //     // Convert the HashSet to a List, sort it by name, and then create a new HashSet
    //     List<GameObject> sortedList = arr.ToList();
    //     sortedList.Sort((a, b) => string.Compare(a.name, b.name));
    //     arr = new HashSet<GameObject>(sortedList);

    //     return arr;
    // }
}
