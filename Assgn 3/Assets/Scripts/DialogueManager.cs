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

    [Header("TEXTS")]
    [SerializeField] private TMP_Text dialogueTextDisplay;
    [SerializeField] private TMP_Text nameTextDisplay;


    [Header("IMAGES")]
    [SerializeField] private Image leftImageIMG;
    [SerializeField] private Image rightImageIMG;


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


        dialogueTextDisplay.text = _dialogue.dialogue;
        nameTextDisplay.text = _dialogue.speakerName;

        currCutscene = _dialogue.nextCutsceneRefId;

        if (_dialogue.currentSpeaker == Dialogue.CurrentSpeaker.RIGHT)
        {
            rightImageIMG.color = Color.white;
            leftImageIMG.color = Color.grey;
        }

        if (_dialogue.currentSpeaker == Dialogue.CurrentSpeaker.LEFT)
        {
            leftImageIMG.color = Color.white;
            rightImageIMG.color = Color.grey;
        }
    }

    // end dialogue function:
    // check the cutsceneset id
    // if the id is 601,
    // game starts

    // if id is 602,
    // endgame sequence commences.
}
