using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;

[System.Serializable]
public class RefDialogue
{
    // IDs
    public string cutsceneRefId;
    public string nextCutsceneRefId;
    public string cutsceneSetId;

    // Images Reference
    public string currentSpeaker;
    public string leftImage;
    public string rightImage;


    // Texts to display
    public string dialogue;
    public string speakerName;
    public string choices;
}
