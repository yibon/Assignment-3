using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public List<GameObject> myIngredients = new List<GameObject>();
    public List<GameObject> receivedIngredient = new List<GameObject>();
    public bool recipeComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in this.transform){
            myIngredients.Add(child.gameObject);
        }
        
        myIngredients.Sort(CompareByName);
       
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
        
        receivedIngredient.Sort(CompareByName);

        if (myIngredients.Count != receivedIngredient.Count)
            return false;
        
        for(int i=0; i<receivedIngredient.Count; i++){
            if (receivedIngredient[i] != myIngredients[i])
                return false;
        }

        return true;
    }
   
    public void AddToBowl(GameObject ingredient){
        
        foreach(GameObject child in myIngredients){
            if(child.name == ingredient.name)    {
                receivedIngredient.Add(child);
                child.SetActive(false);
                break;
            }
        }
        receivedIngredient.Sort(CompareByName);
    }

     // Comparison method to sort GameObjects by their names
    private int CompareByName(GameObject a, GameObject b)
    {
        return a.name.CompareTo(b.name);
    }
}
