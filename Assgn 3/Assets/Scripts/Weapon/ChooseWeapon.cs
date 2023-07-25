// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: ChooseWeapon.cs
// Author: Stella Tan

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class ChooseWeapon : MonoBehaviour
{
    // Array for both weaponWrapper
    public List<Sprite> weaponImages = new List<Sprite>();
    public List<Weapon> mainWeapons = new List<Weapon>();
    public List<Weapon> ramenWeapons = new List<Weapon>();

    // Currently equipped weaponWrapper
    public Weapon activeMain;
    public Weapon activeRamen;
    private int activeMainIndex;
    private int activeRamenIndex;

    // File path to weapon csv
    private string weaponDatabase = "Assets/Data/Weapon/uxg2520 Game System - Weapons Json.json";

    // UIs
    [SerializeField] private TMPro.TMP_Text mainName, mainAttack, mainAttackSpeed;
    [SerializeField] private TMPro.TMP_Text ramenName, ramenAttack, ramenAttackSpeed;
    [SerializeField] private List<Image> activeWeaponBorder = new List<Image>();
    [SerializeField] private List<Image> selectedWeapon = new List<Image>();
    

    // Start is called before the first frame update
    void Start()
    {
        InitWeaponArray();       
    }

    [Serializable]
    public class WeaponListWrapper
    {
        public List<Weapon> weapons = new List<Weapon>();
    }

    // Init the mainWeapons and ramenWeapons array
    private void InitWeaponArray(){
        // Read all weaponWrapper from csv
        // To read a text file line by line
        if (File.Exists(weaponDatabase)) {
            
            // Store each line in array of strings
            string jsonData = File.ReadAllText(weaponDatabase);

            Debug.Log(jsonData);

            WeaponListWrapper weapons = JsonUtility.FromJson<WeaponListWrapper>(jsonData);

            Debug.Log(" weapon count ::" + weapons.weapons.Count);

            for (int i = 0; i < weapons.weapons.Count; i++)
            {
                // Sort into main or ramen weapon type
                if (weapons.weapons[i].type == "200")
                    mainWeapons.Add(weapons.weapons[i]);
                else if (weapons.weapons[i].type == "201")
                    ramenWeapons.Add(weapons.weapons[i]);

                weapons.weapons[i].sprite = weaponImages[i];
            }
            }

        //for(int i=0; i<lines.Length; i++)
        // {

        // if(i==0)
        //     continue;
        // string[] data = lines[i].Split(",");

        // // Create a weapon object based on details from csv
        // Weapon temp = new Weapon(data[0],data[1],data[2], data[3], data[4], data[5]);

        // // Sort into main or ramen weapon type
        // if(data[1] == "200")
        //     mainWeapons.Add(temp);
        // else if(data[1] == "201")
        //     ramenWeapons.Add(temp);
        //}
        else{
            Debug.Log(weaponDatabase + " do not exist!");
        }

        activeMain = mainWeapons[0];
        activeRamen = ramenWeapons[0];
        activeMainIndex = 0;
        activeRamenIndex = mainWeapons.Count;
        UpdateWeaponInfo();
    }
    // Update UI on attack and attack speed as well as color
    private void UpdateWeaponInfo(){

        // Main Weapon 
        mainName.text = "Name: " + activeMain.GetData("name").ToString();
        mainAttack.text = "Attack: " + activeMain.GetData("attack").ToString();
        mainAttackSpeed.text = "Speed: " + activeMain.GetData("speed").ToString();

        // Ramen Weapon
        ramenName.text = "Name: " + activeRamen.GetData("name").ToString();
        ramenAttack.text = "Attack: " + activeRamen.GetData("attack").ToString();
        ramenAttackSpeed.text = "Speed: " + activeRamen.GetData("speed").ToString();

        // Update the three boxes' Image for selecting
        for(int i=0; i< activeWeaponBorder.Count; i++){
            if(i == activeMainIndex || i == activeRamenIndex){
                // activeWeaponBorder[i].GetComponent<Image>().color = Color.green;
                activeWeaponBorder[i].GetComponent<Image>().sprite = weaponImages[i];
                if(i >= mainWeapons.Count){
                    // This is ramen weapon
                    selectedWeapon[1].GetComponent<Image>().sprite = weaponImages[i];
                }
                else{
                    selectedWeapon[0].GetComponent<Image>().sprite = weaponImages[i];
                }
            }
            else{
                activeWeaponBorder[i].GetComponent<Image>().sprite = weaponImages[i];
                // selectedWeapon[1].GetComponent<Image>().sprite = weaponImages[i];

            }
        }
    }
    public void SwitchWeapon(string id){

        foreach(Weapon weapon in mainWeapons){
            if(id == weapon.GetData("id")){
                activeMain = weapon;
                activeMainIndex = mainWeapons.IndexOf(weapon);
                UpdateWeaponInfo();
                break;
            }
        }
        foreach(Weapon weapon in ramenWeapons){
            if(id == weapon.GetData("id")){
                activeRamen = weapon;
                activeRamenIndex = 3 + ramenWeapons.IndexOf(weapon);
                UpdateWeaponInfo();
                break;
            }
        }
    }
    /// <summary>
    /// Loads the main scene
    /// </summary>
    public void ContinueToMainScene()
    {
        Player.MainWeapon = activeMain;
        Player.RamenWeapon = activeRamen;
        SceneLoader.LoadScene(SceneLoader.Scenes.MainScene);
    }
   
}