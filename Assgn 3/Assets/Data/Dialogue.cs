using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    // IDs
    public string cutsceneRefId { get; }
    public string nextCutsceneRefId { get; }
    public string cutsceneSetId { get; }

    // Images Reference
    public CurrentSpeaker currentSpeaker { get; }
    public string leftImage { get; }
    public string rightImage { get; }


    // Texts to display
    public string dialogue { get; }
    public string speakerName { get; }
    public string choices { get; }


    // Constructor
    public Dialogue (string _cutsceneRefId, string _nextCutSceneRefId, string _cutsceneSetId,
                     CurrentSpeaker _currentSpeaker, string _leftImage, string _rightImage, 
                     string _dialogue, string _speakerName, string _choices)
    {
        this.cutsceneRefId = _cutsceneRefId;
        this.nextCutsceneRefId = _nextCutSceneRefId;
        this.cutsceneSetId = _cutsceneSetId;
        this.currentSpeaker = _currentSpeaker;
        this.leftImage = _leftImage;
        this.rightImage = _rightImage;
        this.dialogue = _dialogue;
        this.speakerName = _speakerName;
        this.choices = _choices;
    }

    public enum CurrentSpeaker
    { 
        LEFT,
        RIGHT
    }

}
