using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenes
{
    private string currentCutscene;

    private string currCutsceneId;
    private string nextCutsceneId;
    private string cutsceneSetId;

    // Images Reference
    private Dialogue.CurrentSpeaker currentSpeakerToggle;
    private string leftImageSprite;
    private string rightImageSprite;


    // Texts to display
    private string dialogueText;
    private string speakerNameText;

    private bool isDirty;

    public CutScenes(string currentCutscene)
    {
        this.currentCutscene = currentCutscene;

        isDirty = true;
    }

    public string GetCurrentDialogue()
    {
        return currentCutscene;
    }

    public void SetCurrentDialogue(string dialogue)
    {
        currentCutscene = dialogue;

        isDirty = true;
    }

    public bool UpdateDialogue()
    {
        if (!isDirty) { return false; }

        Dialogue currDialogue = Game.GetDialogueByRefId(currentCutscene);

        currCutsceneId = currDialogue.cutsceneRefId;
        nextCutsceneId = currDialogue.nextCutsceneRefId;
        cutsceneSetId = currDialogue.cutsceneSetId;

        // Images Reference
        currentSpeakerToggle = currDialogue.currentSpeaker;
        leftImageSprite = currDialogue.leftImage;
        rightImageSprite = currDialogue.rightImage;


        // Texts to display
        dialogueText = currDialogue.dialogue;
        speakerNameText = currDialogue.speakerName;

        isDirty = false;

        return true;
    }

    public string GetCurrentDialogueId()
    {
        UpdateDialogue();

        return currCutsceneId;
    }
    public string GetNextDialogueId()
    {
        UpdateDialogue();

        return nextCutsceneId;
    }
    public string GetCutsceneSet()
    {
        UpdateDialogue();

        return cutsceneSetId;
    }
    public Dialogue.CurrentSpeaker GetCurrentSpeaker()
    {
        UpdateDialogue();

        return currentSpeakerToggle;
    }
    public string GetLeftImage()
    {
        UpdateDialogue();

        return leftImageSprite;
    }
    public string GetRightImage()
    {
        UpdateDialogue();

        return rightImageSprite;
    }

    public string GetDialogueText()
    {
        UpdateDialogue();

        return dialogueText;
    }
    public string GetSpeakerName()
    {
        UpdateDialogue();

        return speakerNameText;
    }
}
