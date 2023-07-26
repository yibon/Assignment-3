// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: CharacterSelect.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public static bool characterChosen;
    // Replace this with the UpdateCharacterStats();
    public static string currCharacter;
    public static Sprite curreCharacterSprite;

    private Player player;

    private DataManager dataManager;

    [SerializeField] private Image characterImage;
    [SerializeField] private Image buttonImage;
    [SerializeField] private List<Sprite> characterSprites;
    [SerializeField] private List<Sprite> fullSizedCharacterSprites;
    [SerializeField] private List<Image> characterChoices;

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text hpText;
    //[SerializeField] private TMP_Text attText;
    [SerializeField] private TMP_Text speedText;

    private Character _character;

    private void Start()
    {
        dataManager = GetComponent<DataManager>();

        Debug.Log("CharacterSelect Loaded!");
        Choice1();
        _character = Game.GetCharacterByRefId(currCharacter);
        for (int i = 0; i < characterChoices.Count; i++)
        {
            characterChoices[i].sprite = characterSprites[i];
        }
    }

    private void Update()
    {
        if (_character != null)
        {
            _character = Game.GetCharacterByRefId(currCharacter);
            buttonImage.color = Color.white;
            characterChosen = true;
            nameText.text = _character.characterName;
            hpText.text = "HP: " + _character.characterHP.ToString();
            //attText.text = "Attack: " + _character.characterAttk.ToString();
            speedText.text = "Speed: " + _character.characterMoveSpeed.ToString();



        }

        else
        {
            nameText.text = "Choose Your Character";
            hpText.text = "HP: ";
            //attText.text = "Attack: ";
            speedText.text = "Speed: ";
        }
    }

    public void Choice1()
    {
        currCharacter = "1";
        
        _character = Game.GetCharacterByRefId(currCharacter);
        characterImage.sprite = fullSizedCharacterSprites[0];
        curreCharacterSprite = fullSizedCharacterSprites[0];
    }

    public void Choice2()
    {
        currCharacter = "2";
        _character = Game.GetCharacterByRefId(currCharacter);
        characterImage.sprite = fullSizedCharacterSprites[1];
        curreCharacterSprite = fullSizedCharacterSprites[1];
    }

    public void Choice3()
    {
        currCharacter = "3";
        _character = Game.GetCharacterByRefId(currCharacter);
        characterImage.sprite = fullSizedCharacterSprites[2];
        curreCharacterSprite = fullSizedCharacterSprites[2];
    }

    public void Proceed()
    {
        if (characterChosen)
        {
            SceneLoader.LoadScene(SceneLoader.Scenes.WeaponSelection);
        }
    }

}
