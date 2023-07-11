using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Dialogue _dialogue;
    private string currCutscene;
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
        DataManager dataManager = GetComponent<DataManager>();
        dataManager.LoadDialogueRefData();

        currCutscene = "601001";
        //_dialogue = Game.GetDialogueByRefId(currCutscene);

        NextLine();

    }

    // in update,
    private void Update()
    {

        //Debug.Log(currCutscene);

        // get mouse input/next line input
        if (Input.GetMouseButtonDown(0))
        {
            // nextline function
            NextLine();
        }

    }

    private void NextLine()
    {
        _dialogue = Game.GetDialogueByRefId(currCutscene);

        // Checking if the current scene is the end
        if (currCutscene == "-1") { SceneLoader.LoadScene(SceneLoader.Scenes.CharacterSelect); return; }

        AssetManager.LoadSprite(_dialogue.leftImage, (Sprite s) =>
        {
            leftImageIMG.sprite = s;
        });

        AssetManager.LoadSprite(_dialogue.rightImage, (Sprite s) =>
        {
            rightImageIMG.sprite = s;
        });


        if (_dialogue.dialogue == "-1")
        {
            ChoicesSplit();
            dialogueTextDisplay.text = " ";
            firstChoice.SetActive(true);
            secondChoice.SetActive(true);

            firstChoiceDisplay.text = splitedChoices[0];
            secondChoiceDisplay.text = splitedChoices[2];
            //Debug.Log("EKWOPKFEWOF");
        }

        else
        {
            dialogueTextDisplay.text = _dialogue.dialogue;
            nameTextDisplay.text = _dialogue.speakerName;

            ImageDim(_dialogue.currentSpeaker);
            currCutscene = _dialogue.nextCutsceneRefId;

            firstChoice.SetActive(false);
            secondChoice.SetActive(false);
        }
    }

    // end dialogue function:
    // check the cutsceneset id
    // if the id is 601,
    // game starts

    // if id is 602,
    // endgame sequence commences.

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
        // Replace this with the choices section from csv
        currCutscene = splitedChoices[1];
    }

    public void SecondChoice()
    {
        // Replace this with the choices section from csv
        currCutscene = splitedChoices[3];
    }

    private void ChoicesSplit()
    {
        splitedChoices = _dialogue.choices.Split('#', '@', '#');

        for (int i = 1; i < splitedChoices.Length; i += 2)
        {
            Debug.Log(splitedChoices[i]);
        }
    }

}


