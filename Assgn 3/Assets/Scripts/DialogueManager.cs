using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private CutScenes cutscene;

    private Dialogue _dialogue;
    private string currCutscene;

    private List<Dialogue> _dialogueList;
    private int currIndex;


    [Header("TEXTS")]
    [SerializeField] private TMP_Text dialogueTextDisplay;
    [SerializeField] private TMP_Text nameTextDisplay;


    private void Start()
    {
        DataManager dataManager = GetComponent<DataManager>();

        dataManager.LoadRefData();

        _dialogueList = Game.GetDialogueList();


        //  currCutscene = cutscenered
        currCutscene = "601001";
    }

    // in update,
    private void Update()
    {
        _dialogue = Game.GetDialogueByRefId(currCutscene);

        // get mouse input/next line input
        if (Input.GetMouseButtonDown(0))
        {
            // nextline function
            NextLine();
        }

    }

    private void NextLine()
    {
        // Checking if the current scene is not the end
        Debug.Log(currCutscene);

        if (currCutscene != "-1")
        {
            dialogueTextDisplay.text = _dialogue.dialogue;
            nameTextDisplay.text = _dialogue.speakerName;

            currCutscene = _dialogue.nextCutsceneRefId;
        }

        else
        {
            Debug.Log("End of Dialogue");
        }

    }

    //  if (currCutScene is not -1)
    //  {	
    //	dialogue text = dialogue


    //    check if the speaker is the left or right speaker
    //		if left,
    //			name text = left speaker
    //            dull the right image(using tint?)
    //		if right,
    //			name text = right speaker
    //			dull the left image

    //	    currCutScene = next cutscene
    //  }

    //  else
    //  {
    //       end dialogue function
    //  }


    //  nextline function:

    // end dialogue function:
    // check the cutsceneset id
    // if the id is 601,
    // game starts

    // if id is 602,
    // endgame sequence commences.
}
