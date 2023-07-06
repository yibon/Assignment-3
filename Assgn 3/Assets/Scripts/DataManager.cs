using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.TextCore.Text;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadDialogueRefData();
        LoadRefCharacterData();
    }

    public void LoadDialogueRefData()
    {
        string filePath = Path.Combine(Application.dataPath, "Data/dialogue_data.txt");
        string dataString = File.ReadAllText(filePath);

        // Tell the json file that you would like to get data from data string into the dialogue data class
        RefData dialogueData = JsonUtility.FromJson<RefData>(dataString);

        // Process Data
        ProcessDialogueData(dialogueData);
    }

    private void ProcessDialogueData(RefData dialogueData)
    {
        // Dialogue Table
        List<Dialogue> dialoguelist = new List<Dialogue>();

        foreach (RefDialogue refDialogue in dialogueData.RefDialogue)
        {
            Dialogue.CurrentSpeaker currSpeaker = (Dialogue.CurrentSpeaker)System.Enum.Parse(typeof(Dialogue.CurrentSpeaker), refDialogue.currentSpeaker);

            Dialogue dialogue = new Dialogue(refDialogue.cutsceneRefId, refDialogue.nextCutsceneRefId, refDialogue.cutsceneSetId,
                                             currSpeaker, refDialogue.leftImage, refDialogue.rightImage,
                                             refDialogue.dialogue, refDialogue.speakerName);

            dialoguelist.Add(dialogue);
        }

        Game.SetDialogueList(dialoguelist);

        // Debug.Log(Game.GetDialogueList().Count);
    }

    public void LoadRefCharacterData()
    {
        string filePath = Path.Combine(Application.dataPath, "Data/character_data.txt");
        string dataString = File.ReadAllText(filePath);

        // Tell the json file that you would like to get data from data string into the dialogue data class
        RefData characterData = JsonUtility.FromJson<RefData>(dataString);

        // Process Data
        ProcessCharacterData(characterData);
    }

    private void ProcessCharacterData(RefData characterData)
    {
        // Character Table
        List<Character> characterlist = new List<Character>();

        foreach (RefCharacter refCharacter in characterData.RefCharacter)
        {
            Character character = new Character(refCharacter.characterId, refCharacter.characterName, refCharacter.characterHP,
                refCharacter.characterAttk, refCharacter.characterMoveSpeed);

            characterlist.Add(character);
        }

        Game.SetCharacterList(characterlist);
        Debug.Log(Game.GetCharacterList().Count);
    }
}

