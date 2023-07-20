using System.IO;
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
    [SerializeField] public List<Sprite> allIngredients = new List<Sprite>();

    private Vector3 minRandPoint = new Vector3(-8, -4, 0);
    private Vector3 maxRandPoint = new Vector3(8, 4, 0);
    private List<Color> colors = new List<Color>(){Color.red, Color.blue, Color.green};

    public List<GameObject> pickedUp = new List<GameObject>();
    public BowlController bowlController;
    
    public WaveList waveList;
    public List<WaveData> waveDatas = new List<WaveData>();
    public int waveCounter = 0;
    [SerializeField] private int spawnedCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Read json
        string json_wave = "Assets/Data/JSON/ingredientwave.json";
        
        if (File.Exists(json_wave))
        {
            string jsonData = File.ReadAllText(json_wave);

            // Deserialize the JSON data into C# objects
            waveList = JsonUtility.FromJson<WaveList>(jsonData);
            
            

            // Access the data
            foreach (WaveData waveData in waveList.ingredientwave)
            {
                waveData.SetIngredientLists(waveData.IngredientId);
                waveData.SetIngredientCount(waveData.ingredientCount);
                waveData.SetIngredientPosition(waveData.spawnPositionMin, waveData.spawnPositionMax);
                // Debug.LogWarning("Test:" + waveData.ingredientCountList[0]);
                // waveData.ingredientCountList[0] -= 1;
                // Debug.LogWarning("Test:" + waveData.ingredientCountList[0]);

                // Debug.LogWarning("Test:" + waveData.ingredientCountList[0]-1);
                // Debug.LogWarning("Test:" + waveData.ingredientCountList[0]);
                waveDatas.Add(waveData);
            }
            
        }
        else
        {
            Debug.LogError("JSON file not found: " + waveList);
        }

        InitIngredients();
        pickedUp.Add(null);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnIngredient();
        CheckIfPickedUpOthers();
    }

    // Spawn defaultIngredientCount number of ingredients
    private void InitIngredients(){

        for (int i = 0; i < defaultIngredientCount; i++)
        {
            spawnedCount++;
            canRespawn = true;
            SpawnIngredient();
        }
    }
    private void SpawnIngredient(){

        // We only want to have defaultIngredientCount num of ingredient on scene at any time
        // if(spawnedCount>= defaultIngredientCount){
        //     canRespawn = false;
        // }
        // else{
        //     canRespawn = true;
        // }


        if(canRespawn){
            canRespawn = false;

            // Check if all ingredientCountList is empty or not, if yes, move on to next spawn
            bool empty = true;
            foreach(int remainingIngredient in waveDatas[waveCounter].ingredientCountList){
                if(remainingIngredient!=0)
                    empty = false;
                    break;
            }
            if(empty){
                // Increment current wave counter to go to next stage
                waveCounter++;
            }


            WaveData currWave = waveDatas[waveCounter];

            int randIndex =0;
            
            bool valid = false;
            while(!valid){
                randIndex = Random.Range(0, currWave.ingredientList.Length);
                if(currWave.ingredientCountList[randIndex] > 0)
                    valid = true;
            }

            if(valid){
                string ingredientToSpawn = currWave.ingredientList[randIndex];
                // Only allow spawning IF countlist is above 0
                if(currWave.ingredientCountList[randIndex] > 0){
                    // Can spawn this ingredient
                    // After every spawn, ingredient used up
                    currWave.ingredientCountList[randIndex]--;

                    // Positions
                    minRandPoint = currWave.minPosition;
                    maxRandPoint = currWave.maxPosition;
                    Vector3 randPoint = new Vector3(Random.Range(minRandPoint.x, maxRandPoint.x),Random.Range(minRandPoint.y, maxRandPoint.y),0);
                    
                    // Ingredient object
                    GameObject newIngredient = Instantiate(ingredientPrefab, randPoint, transform.rotation);
                    newIngredient.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    foreach(Sprite sprite in allIngredients){
                        if(sprite.name == ingredientToSpawn){
                            newIngredient.GetComponent<SpriteRenderer>().sprite = sprite;
                            newIngredient.name = sprite.name;
                            break;
                        }
                    }

                    
                }
                else{
                    
                }
            }
            // Debug.LogWarning("current wave: " + currWave.ingredientCountList[0]);
            
            
            // Debug.LogWarning("current wave: " + currWave.ingredientCountList[0]);
            
            // Debug.LogWarning("current wave: " +waveDatas[1]);
            // Debug.LogWarning("current wave: " + waveDatas[waveCounter][0]);
            // Debug.LogWarning("current wave: " + waveDatas[waveCounter][1]);

            // int randIndex=2;
            // Vector3 randPoint = new Vector3(Random.Range(minRandPoint.x, maxRandPoint.x),Random.Range(minRandPoint.y, maxRandPoint.y),0);
            // GameObject newIngredient = Instantiate(ingredientPrefab, randPoint, transform.rotation);

            // newIngredient.GetComponent<SpriteRenderer>().sprite = allIngredients[randIndex];
            // newIngredient.GetComponent<Transform>().localScale = new Vector3(0.1f,0.1f,0.1f);
            // newIngredient.name = allIngredients[randIndex].name;
        }
    }

    // private void SpawnIngredient(){
    //     if(canRespawn){
    //         canRespawn = false;
    //         int randIndex = Random.Range(0, allIngredients.Count);
    //         Vector3 randPoint = new Vector3(Random.Range(minRandPoint.x, maxRandPoint.x),Random.Range(minRandPoint.y, maxRandPoint.y),0);
    //         GameObject newIngredient = Instantiate(ingredientPrefab, randPoint, transform.rotation);
    //         newIngredient.GetComponent<SpriteRenderer>().sprite = allIngredients[randIndex];
    //         newIngredient.GetComponent<Transform>().localScale = new Vector3(0.1f,0.1f,0.1f);
    //         newIngredient.name = allIngredients[randIndex].name;
    //     }
    // }
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
        spawnedCount--;
        StartCoroutine(Countdown());
    }
    private IEnumerator Countdown() {
        yield return new WaitForSeconds(respawnTimer); //wait 3 seconds
        canRespawn = true;
    }
}
