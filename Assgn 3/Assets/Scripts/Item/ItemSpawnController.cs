using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawnController : MonoBehaviour
{
    [SerializeField] private int respawnTimer = 3;
    [SerializeField] private int defaultIngredientCount = 4;
    [SerializeField] private bool canRespawn = false;

    [SerializeField] private GameObject ingredientPrefab;
    // [SerializeField] private List<Image> allIngredients = new List<Image>();
    [SerializeField] private List<Sprite> allIngredients = new List<Sprite>();

    private Vector3 minRandPoint = new Vector3(-8, -4, 0);
    private Vector3 maxRandPoint = new Vector3(8, 4, 0);
    private List<Color> colors = new List<Color>(){Color.red, Color.blue, Color.green};

    public List<GameObject> pickedUp = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InitIngredients();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnIngredient();
        CheckIfPickedUpOthers();
    }

    // Spawn defaultIngredientCount number of ingredients
    private void InitIngredients(){
        int spawnedCount = 0;
        while(spawnedCount < defaultIngredientCount){
            spawnedCount++;
            canRespawn = true;
            SpawnIngredient();
        }
    }
    private void SpawnIngredient(){
        if(canRespawn){
            canRespawn = false;
            int randIndex = Random.Range(0, allIngredients.Count);
            Vector3 randPoint = new Vector3(Random.Range(minRandPoint.x, maxRandPoint.x),Random.Range(minRandPoint.y, maxRandPoint.y),0);
            GameObject newIngredient = Instantiate(ingredientPrefab, randPoint, transform.rotation);
            newIngredient.GetComponent<SpriteRenderer>().sprite = allIngredients[randIndex];
            newIngredient.GetComponent<Transform>().localScale = new Vector3(0.1f,0.1f,0.1f);
            newIngredient.name = allIngredients[randIndex].name;
        }
    }
    private void CheckIfPickedUpOthers(){
        if(pickedUp.Count > 1){
            for(int i=0; i<pickedUp.Count-1; i++){
                Destroy(pickedUp[i]);
                pickedUp.Remove(pickedUp[i]);
            }

            
        }
    }
    public void Trigger(){
        // Pickup-ed, now wait for 10 seconds to spawn new
        StartCoroutine(Countdown());
    }
    private IEnumerator Countdown() {
        yield return new WaitForSeconds(respawnTimer); //wait 3 seconds
        canRespawn = true;
    }
}
