// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: CharacterSelect.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public static bool characterChosen;
    // Replace this with the UpdateCharacterStats();
    public static string currCharacter;

    private Player player;

    [SerializeField] private Image characterImage;
    [SerializeField] private Image buttonImage;

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text attText;
    [SerializeField] private TMP_Text speedText;

    private Character _character;

    private void Start()
    {
        //DataManager dataManager = GetComponent<DataManager>();
        //dataManager.LoadRefCharacterData(OnDataLoad);
        Debug.Log("CharacterSelect Loaded!");
        _character = Game.GetCharacterByRefId(currCharacter);
    }

    //private void OnDataLoad()
    //{
    //}

    private void Update()
    {

        if (_character != null)
        {
            _character = Game.GetCharacterByRefId(currCharacter);
            buttonImage.color = Color.white;
            characterChosen = true;
            //Debug.Log(_character.characterId);
            nameText.text = _character.characterName;
            hpText.text = "HP: " + _character.characterHP.ToString();
            attText.text = "Attack: " + _character.characterAttk.ToString();
            speedText.text = "Speed: " + _character.characterMoveSpeed.ToString();
        }

        else
        {
            nameText.text = "Choose Your Character";
            hpText.text = "HP: ";
            attText.text = "Attack: ";
            speedText.text = "Speed: ";
        }
    }

    public void Choice1()
    {
        currCharacter = "1";
        _character = Game.GetCharacterByRefId(currCharacter);
        characterImage.color = Color.red;
    }

    public void Choice2()
    {
        currCharacter = "2";
        _character = Game.GetCharacterByRefId(currCharacter);
        characterImage.color = Color.green;
    }

    public void Choice3()
    {
        currCharacter = "3";
        _character = Game.GetCharacterByRefId(currCharacter);
        characterImage.color = Color.blue;
    }

    public void Proceed()
    {
        if (characterChosen)
        {
            SceneLoader.LoadScene(SceneLoader.Scenes.WeaponSelection);
        }
    }

}
