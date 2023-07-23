// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: DialogueManager.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Dialogue _dialogue;
    public static string currDialogue;
    public static string currCutscene;

    private string[] splitedChoices;
    //private string[] splitedIds;

    [Header("TEXTS")]
    [SerializeField] private TMP_Text dialogueTextDisplay;
    [SerializeField] private TMP_Text nameTextDisplay;
    [SerializeField] private TMP_Text firstChoiceDisplay;
    [SerializeField] private TMP_Text secondChoiceDisplay;


    [Header("IMAGES")]
    [SerializeField] private Image leftImageIMG;
    [SerializeField] private Image rightImageIMG;

    [Header("CHOICES")]
    [SerializeField] private GameObject firstChoice;
    [SerializeField] private GameObject secondChoice;


    private void Start()
    {
        //DataManager dataManager = GetComponent<DataManager>();
        //dataManager.LoadRefDialogueData(OnDataLoad);

        // Comment this line when there are multiple dialogues involved
        //_dialogue = Game.GetDialogueByRefId(currCutscene);


        switch (currCutscene)
        {
            case "601":
                currDialogue = "601001";
                break;
            case "602":
                currDialogue = "602001";
                break;
        }

        NextLine();
    }

    //public void OnDataLoad()
    //{
    //}

    // in update,
    private void Update()
    {

        // get mouse input/next line input
        if (Input.GetMouseButtonDown(0))
        {
            // nextline function
            NextLine();
        }
    }

    private void NextLine()
    {
        _dialogue = Game.GetDialogueByRefId(currDialogue);
        Debug.Log(currDialogue);

        // Checking if the current scene is the end
        //if (currDialogue == "-1") 
        //{
        // this is giving an error because there is no currcutscene in currdialogue
        // ways around: check the next cutscene (but this will probably make it switch scenes prematurely)
        // other way around: add a new line in the excel where it catches the currdialogue as -1 (will have two -1 currdialogue)
        // make each end-identifier unique

        if (currDialogue == "-1")
        {
            switch (currCutscene)
            {
                case "601":
                    SceneLoader.LoadScene(SceneLoader.Scenes.CharacterSelect);
                    return;

                case "602":
                    SceneLoader.LoadScene(SceneLoader.Scenes.WinScreen);
                    return;
            }
        }

        AssetManager.LoadSprite(_dialogue.leftImage, (Sprite s) =>
        {
            leftImageIMG.sprite = s;
        });

        AssetManager.LoadSprite(_dialogue.rightImage, (Sprite s) =>
        {
            rightImageIMG.sprite = s;
        });


        if (_dialogue.nextCutsceneRefId == "-2")
        {
            ChoicesSplit();
            firstChoice.SetActive(true);
            secondChoice.SetActive(true);

            dialogueTextDisplay.text = " ";
            firstChoiceDisplay.text = splitedChoices[0];
            secondChoiceDisplay.text = splitedChoices[2];
        }

        else
        {
            dialogueTextDisplay.text = _dialogue.dialogue;
            nameTextDisplay.text = _dialogue.speakerName;

            ImageDim(_dialogue.currentSpeaker);

            firstChoice.SetActive(false);
            secondChoice.SetActive(false);

            currDialogue = _dialogue.nextCutsceneRefId;
        }
    }

    private void ImageDim(Dialogue.CurrentSpeaker currSpeaker)
    {
        if (currSpeaker == Dialogue.CurrentSpeaker.RIGHT)
        {
            rightImageIMG.color = Color.white;
            leftImageIMG.color = Color.grey;
        }

        if (currSpeaker == Dialogue.CurrentSpeaker.LEFT)
        {
            leftImageIMG.color = Color.white;
            rightImageIMG.color = Color.grey;
        }
    }

    public void FirstChoice()
    {
        //Debug.Log("Hello World");
        currDialogue = splitedChoices[1];
        NextLine();
    }

    public void SecondChoice()
    {
        currDialogue = splitedChoices[3];
        NextLine();
    }

    private void ChoicesSplit()
    {
        splitedChoices = _dialogue.choices.Split('#', '@', '#');
    }
}


